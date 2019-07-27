using CatMash.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Models
{
    public class VoteModel
    {
        public Cat FirstCat { get; set; }

        public Cat SecondCat { get; set; }

        public int WinnerCatId { get; set; }

        public int LoserCatId { get; set; }
    }
}
