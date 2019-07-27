using CatMash.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.DataAccess.Repositories
{
    public interface ICatRepository
    {
        Cat GetCatById(int id);

        IEnumerable<Cat> GetAllCat();

        int AddVote(Vote vote);

        Cat GetRandomCat();
    }
}
