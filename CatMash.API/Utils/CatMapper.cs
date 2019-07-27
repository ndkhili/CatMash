using CatMash.API.DataAccess.Models;
using CatMash.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Utils
{ 
    public static class CatMapper
    {
        public static CatDto ToModelCat(this TCat cat)
        {
            if (cat == null)
                return null;

            return new CatDto
            {
                Id = cat.CatId,
                Url = cat.Url,
            };
        }
    }
}
