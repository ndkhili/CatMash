using CatMash.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Business
{ 
    public interface ICatService
    {
        GetCatScoresResponseDto GetCatScores();

        bool InsertVote(VoteDto vote);

        Tuple<CatDto, CatDto> GetCandidatesCats();
    }
}
