using System.Collections.Generic;
using CrudApp1.Models;

namespace CrudApp1.Repositories
{
    public interface IAlbumsRepository
    {
        IList<Album> GetAll();
        void Insert(Album album);
        void DeleteByName(Album album);
        void UpdateById(Album album);
    }
}