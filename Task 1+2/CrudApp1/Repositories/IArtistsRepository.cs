using System.Collections.Generic;
using CrudApp1.Models;

namespace CrudApp1.Repositories
{
    internal interface IArtistsRepository
    {
        IList<Artist> GetAll();
        void Insert(Artist artist);
        void DeleteByName(Artist artist);
        void UpdateById(Artist artist);
    }
}