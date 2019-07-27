using System;
using System.Collections.Generic;

namespace CatMash.API.DataAccess.Models
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int WinCatId { get; set; }
        public int LostCatId { get; set; }
        public DateTime? CreationDate { get; set; }

        public Cat LostCat { get; set; }
        public Cat WinCat { get; set; }
    }
}
