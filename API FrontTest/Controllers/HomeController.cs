using API_FrontTest.Models;
using API_FrontTest.Models.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_FrontTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaPersonas()
        {
            return RedirectToAction("Index", "Persona");
        }
        public IActionResult ListaEquipos()
        {
            return RedirectToAction("Index", "Equipo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}