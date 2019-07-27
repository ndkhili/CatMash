using CatMash.API.DataAccess.Repositories;
using CatMash.API.DTOs;
using CatMash.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CatMash.API.Business
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public IEnumerable<CatDto> GetCatScores()
        {
            var dbCats = _catRepository.GetAllCat();

            var cats = new List<CatDto>();

            foreach (var cat in dbCats)
            {
                cats.Add(new CatDto
                {
                    Id = cat.CatId,
                    Url = cat.Url,
                    Score = ScoreCalculator.CalculateScore(cat.VoteWinCat.Count(), cat.VoteLostCat.Count())
                });
            }

            return cats.OrderByDescending(c => c.Score?.Value);

        }

        public Tuple<CatDto, CatDto> GetCandidatesCats()
        {
            var firstCat = _catRepository.GetRandomCat().ToModelCat();

            CatDto secondCat = null;
            var isSecond = false;
            var maxTries = 30;
            var tries = 0;

            while (!isSecond && tries < maxTries)
            {
                tries++;

                var cat = _catRepository.GetRandomCat().ToModelCat();
                if (cat.Id != firstCat.Id)
                {
                    secondCat = cat;
                    isSecond = true;
                }
            }

            if (secondCat == null)
            {
                return null;
            }
            else
            {
                return Tuple.Create(firstCat, secondCat);
            }

        }

        public bool InsertVote(VoteDto voteDto)
        {
            var vote = VoteMapper.Map(voteDto);
            var updateCount = _catRepository.AddVote(vote);

            return updateCount > 0;
        }
    }
}
