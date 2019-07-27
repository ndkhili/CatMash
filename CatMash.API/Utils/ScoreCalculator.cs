using CatMash.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Utils
{
    public static class ScoreCalculator
    {
        private static readonly int WIN_WEIGHT = 5;
        private static readonly int LOST_WEIGHT = 1;

        public static ScoreDto CalculateScore(int winVoteCount, int lostVoteCount) => new ScoreDto
        {
            LostVoteCount = lostVoteCount,
            WinVoteCount = winVoteCount,
            Value = winVoteCount * WIN_WEIGHT - lostVoteCount * LOST_WEIGHT
        };
    }
}
