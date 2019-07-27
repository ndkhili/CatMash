using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.MVC.Business;
using CatMash.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.MVC.Controllers
{
    public class CatController : Controller
    {
        private readonly ICatService _catService;

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        public async Task<IActionResult> Scores()
        {
            CatScoresModel model = await _catService.GetCatScores();

            return View(model);
        }

        public async Task<IActionResult> Vote()
        {
            var cats = await _catService.GetCatsForVote();
            var model = new VoteModel
            {
                FirstCat = cats.Item1,
                SecondCat = cats.Item2,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Vote([FromBody]VoteModel model)
        {
            try
            {
                await _catService.SendVote(model);
                return Json("OK");
            }
            catch
            {
                return Json("KO");
            }
        }
    }
}