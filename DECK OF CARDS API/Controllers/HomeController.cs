using DECK_OF_CARDS_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DECK_OF_CARDS_API.Controllers
{
    public class HomeController : Controller
    {
        Deck NDeck = new Deck();
        public IActionResult Index()
        {
          
            ViewModel vm = new ViewModel();
            vm.AllCards = NDeck.NewDeck();

            return View(vm);
        }

        public IActionResult Drawed(Cards d, int draw)
        {
            ViewModel vm = new ViewModel();
            vm.AllCardsDrawed = NDeck.DrawCard(d,draw);
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
