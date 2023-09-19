using System;
using System.Linq;
using ConsoleApp1;
//using CrudApp1.Models;
using CrudApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using static ConsoleApp1.NeondbContext;

namespace CrudApp1
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            
            using (NeondbContext db = new NeondbContext()) //Read
            {
                // получаем объекты из бд и выводим на консоль
                var albums = db.Albums.ToList();
                Console.WriteLine("Данные:");
                foreach (Album a in albums)
                {
                    Console.WriteLine($"{a.AlbumName}, {a.Year}");
                }
            }
            
            /*using (NeondbContext db = new NeondbContext()) //Create
            {
                var artist = db.Artists.SingleOrDefault(a => a.ArtistName == "Lil Uzi Vert");
                Album album = new Album { AlbumName = "Eternal Atake", Year = 2019, Artist = artist};

                // Добавление
                db.Albums.Add(album);
                db.SaveChanges();
                
                Console.WriteLine("Данные после добавления:");
                foreach (Album a in albums)
                {
                    Console.WriteLine($"{a.AlbumName}, {a.Year}");
                }
            }*/
            
            /*using (NeondbContext db = new NeondbContext()) //Update
            {
                var album = db.Albums.SingleOrDefault(a => a.AlbumName == "Eternal Atake");
                if (album != null)
                {
                    album.AlbumName = "Eternal Atake";
                    album.Year = 2020;

                    db.Albums.Update(album);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var albums = db.Albums.ToList();
                foreach (Album a in albums)
                {
                    Console.WriteLine($"{a.Year}, {a.AlbumName}");
                }
            }*/
            
            using (NeondbContext db = new NeondbContext()) //Delete
            {
                var album = db.Albums.SingleOrDefault(a => a.AlbumName == "Eternal Atake");
                if (album != null)
                {
                    db.Albums.Remove(album);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var albums = db.Albums.ToList();
                foreach (Album a in albums)
                {
                    Console.WriteLine($"{a.Year}, {a.AlbumName}");
                }
            }
            
            
            string GetTableChoice()
            {
                Console.WriteLine("Type table name");
                return Console.ReadLine();
            }
        }
    }
}