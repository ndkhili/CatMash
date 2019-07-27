using CatMash.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.DataAccess.Repositories
{
    public interface ICatRepository
    {
        TCat GetCatById(int id);

        IEnumerable<TCat> GetAllCat();

        int AddVote(TVote vote);

        TCat GetRandomCat();
    }
}
