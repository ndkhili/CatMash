using CatMash.MVC.Entities;
using CatMash.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Business
{
    public interface ICatService
    {
        Task<CatScoresModel> GetCatScores();

        Task SendVote(VoteModel vote);

        Task<Tuple<Cat, Cat>> GetCatsForVote();
    }
}
