using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.DTOs
{
    public class CatDto
    {
        public int Id { get; set; }
         
        public string Url { get; set; }

        public ScoreDto Score { get; set; }
    }
}
