using Microsoft.AspNetCore.Mvc;
using MyDemoMvc.Models;
using System.Diagnostics;

namespace MyDemoMvc.Controllers
{
    [Route("gestao")]
    public class HomeController : Controller
    {
        [Route("")]
        //[Route("pagina-inicial")]
        //[Route("pagina-inicial/{id:int}/{categoria?}")]
        public IActionResult Index()
        {
            var filme = new Filme
            {
                Titulo = "Filme 01",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };
            return RedirectToAction("Privacy", filme);
            //return View();
        }

        [Route("privacy")]
        public IActionResult Privacy(Filme filme)
        {
            if (ModelState.IsValid)
            {

            }

            foreach(var error in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}