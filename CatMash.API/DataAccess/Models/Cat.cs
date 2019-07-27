using System;
using System.Collections.Generic;

namespace CatMash.API.DataAccess.Models
{
    public partial class Cat
    {
        public Cat()
        {
            VoteLostCat = new HashSet<Vote>();
            VoteWinCat = new HashSet<Vote>();
        }

        public int CatId { get; set; }
        public string Url { get; set; }

        public ICollection<Vote> VoteLostCat { get; set; }
        public ICollection<Vote> VoteWinCat { get; set; }
    }
}
