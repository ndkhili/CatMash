using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.API.Business;
using CatMash.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatService _catService;

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        [Route("scores")]
        public IActionResult GetScores()
        {
            var catscoresResponses = _catService.GetCatScores();

            return Ok(catscoresResponses);
        }


        [HttpGet]
        [Route("candidates")]
        public IActionResult Candidates()
        {
            var catscoresResponses = _catService.GetCandidatesCats();

            return Ok(catscoresResponses);
        }

        [HttpPost]
        [Route("vote")]
        public void Vote([FromBody]VoteDto voteDto)
        {
            _catService.InsertVote(voteDto);
        }
    }
}