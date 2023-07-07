using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aarim.Desafio.RickMorty.Services.Interfaces;
using Aarim.Desafio.RickMorty.Web.ViewModel;

namespace Aarim.Desafio.RickMorty.Web
{
    public class HomeController : Controller
    {
        private readonly IRickAndMoryApiService rickAndMortyService;

        public HomeController(IRickAndMoryApiService rickAndMortyService)
        {
            this.rickAndMortyService = rickAndMortyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await rickAndMortyService.GetChallengeAsync();
            return View(model: new IndexModel(result));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await rickAndMortyService.GetAllCharactersAsync();
            return View("Index", model: new IndexModel(result));
        }
    }
}

