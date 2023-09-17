using System;
using CrudApp1.Models;
using CrudApp1.Repositories;

namespace CrudApp1
{
    internal class Program
    {
        private const string connectionString =
            "Host=ep-broad-disk-66916092.us-east-2.aws.neon.tech;Username=dimamatveevdenismatveev;Password=5VnTI3eWMZRQ;Database=neondb";

        private static void Main(string[] args)
        {
            var artistsRepo = new ArtistsRepository(connectionString);
            var albumsRepo = new AlbumsRepository(connectionString);

            while (true)
            {
                Console.WriteLine("1 - Create, 2 - Read, 3 - Update, 4 - Delete");
                var user_command = Convert.ToInt32(Console.ReadLine());
                switch (user_command)
                {
                    case 1: //Create
                        Console.WriteLine("You choose Create operation");
                        var create_table = ChoiseTable();
                        if (create_table.ToLower() == "artists")
                        {
                            Console.WriteLine("type the artist name");
                            artistsRepo.Insert(new Artist { artist_name = Console.ReadLine() });
                            Console.WriteLine("success");
                        }
                        else if (create_table.ToLower() == "albums")
                        {
                            Console.WriteLine("type the album name");
                            var album_name = Console.ReadLine();
                            Console.WriteLine("type the release year");
                            var year = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("type the artist id");
                            var artist_id = Convert.ToInt32(Console.ReadLine());
                            //AddAlbum(album_name, year, artist_id);
                            albumsRepo.Insert(new Album
                                { album_name = album_name, year = year, artist_id = artist_id });
                            Console.WriteLine("success");
                        }

                        break;
                    case 2: //Read

                        Console.WriteLine("You choose Read operation");
                        var read_table = ChoiseTable();
                        if (read_table.ToLower() == "artists")
                            foreach (var item in artistsRepo.GetAll())
                                Console.WriteLine($"{item.artist_name}");

                        else if (read_table.ToLower() == "albums")
                            foreach (var item in albumsRepo.GetAll())
                                Console.WriteLine($"{item.album_name} {item.year} {item.artist_id}");

                        break;
                    case 3: //Update
                        Console.WriteLine("You choose Update operation");
                        var update_table = ChoiseTable();
                        if (update_table.ToLower() == "artists")
                        {
                            Console.WriteLine("type the artist id");
                            var input_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("type the artist name");
                            var input_name = Console.ReadLine();
                            artistsRepo.UpdateById(new Artist { artist_id = input_id, artist_name = input_name });
                            Console.WriteLine("success");
                        }
                        else if (update_table.ToLower() == "albums")
                        {
                            Console.WriteLine("type the album id");
                            var album_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("type the album name");
                            var album_name = Console.ReadLine();
                            Console.WriteLine("type the release year");
                            var year = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("type the artist id");
                            var artist_id = Convert.ToInt32(Console.ReadLine());
                            albumsRepo.UpdateById(new Album
                                { album_id = album_id, album_name = album_name, year = year, artist_id = artist_id });
                            //UpdateAlbum(album_id, album_name, year, artist_id);
                            Console.WriteLine("success");
                        }

                        break;
                    case 4: //Delete
                        Console.WriteLine("You choose Delete operation");
                        var delete_table = ChoiseTable();
                        if (delete_table.ToLower() == "artists")
                        {
                            Console.WriteLine("type the artist name");
                            artistsRepo.DeleteByName(new Artist { artist_name = Console.ReadLine() });
                            Console.WriteLine("success");
                        }
                        else if (delete_table.ToLower() == "albums")
                        {
                            Console.WriteLine("type the album name");
                            var album_name = Console.ReadLine();
                            albumsRepo.DeleteByName(new Album { album_name = album_name });
                            //DeleteAlbum(Convert.ToInt32(album_id));
                            Console.WriteLine("success");
                        }

                        break;
                }
            }

            string ChoiseTable()
            {
                string table;
                Console.WriteLine("Type table name");
                table = Console.ReadLine();
                return table;
            }
        }
    }
}