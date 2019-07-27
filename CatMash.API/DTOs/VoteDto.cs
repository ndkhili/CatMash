using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.DTOs
{
    public class VoteDto
    {
        public int WinnerCatId { get; set; }
        public int LoserCatId { get; set; }
    }
}
