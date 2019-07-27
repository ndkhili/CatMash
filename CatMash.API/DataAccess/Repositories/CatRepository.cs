using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CatMash.API.DataAccess.Models;
using CatMash.API.DataAccess.DatabaseContext;

namespace CatMash.API.DataAccess.Repositories
{
    public class CatRepository : ICatRepository
    {
        private readonly CatDBContext _catDbContext;

        public CatRepository(CatDBContext catDbContext)
        {
            _catDbContext = catDbContext;
        }
        
        public IEnumerable<Cat> GetAllCat()
        {
            return _catDbContext.Cats.Include(c=> c.VoteLostCat).Include(cc=>cc.VoteWinCat);
        }

        public Cat GetCatById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _catDbContext.Cats.Where(c => c.CatId == id).FirstOrDefault();
        }

        public int AddVote(Vote vote)
        {
            if(vote == null)
            {
                return 0;
            }

            if (vote.WinCatId <= 0 || vote.LostCatId <= 0 || vote.WinCatId == vote.LostCatId)
            {
                throw new Exception($"Invalid Vote. WinCatId: {vote.WinCatId} / LostCatId: {vote.LostCatId}");
            }

            if (_catDbContext.Cats.Where(c => c.CatId == vote.WinCatId).Count() <= 0)
            {
                throw new Exception($"Cat Not Found for this Vote. CatId : {vote.WinCatId}");
            }

            if (_catDbContext.Cats.Where(c => c.CatId == vote.LostCatId).Count() <= 0)
            {
                throw new Exception($"Cat Not Found for this Vote. CatId : {vote.LostCatId}");
            }

            try
            {
                _catDbContext.Votes.Add(vote);

                return _catDbContext.SaveChanges();
            }
            catch(Exception exp)
            {
                throw new Exception("DataAccessException", exp);
            }
        }
        
        public Cat GetRandomCat()
        {
            var random = new Random();
            var skip = (int)(random.NextDouble() * _catDbContext.Cats.Count());
            return _catDbContext.Cats.OrderBy(c=> c.CatId).Skip(skip).Take(1).First();
        }
    }
}
