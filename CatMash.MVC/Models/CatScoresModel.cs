using CatMash.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Models
{
    public class CatScoresModel
    {
        public IEnumerable<Cat> Cats { get; set; }
    }    
}
