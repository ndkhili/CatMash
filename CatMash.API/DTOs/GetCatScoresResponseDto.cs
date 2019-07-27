using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.DTOs
{
    public class GetCatScoresResponseDto
    {
        public IEnumerable<CatDto> Cats { get; set; }
    }
}
