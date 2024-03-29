﻿using CatMash.API.DataAccess.Models;
using CatMash.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Utils
{
    public static class VoteMapper
    {
        public static Vote Map(VoteDto vote)
        {
            if (vote == null)
            {
                return null;
            }

            return new Vote
            {
                LostCatId = vote.LoserCatId,
                WinCatId = vote.WinnerCatId,
                CreationDate = DateTime.Now
            };
        }
    }
}
