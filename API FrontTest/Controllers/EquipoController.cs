using API_FrontTest.Models;
using API_FrontTest.Models.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API_FrontTest.Controllers
{
    public class EquipoController : Controller
    {
        private readonly IServicioEquipo _servicioApi;

        public EquipoController(IServicioEquipo servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Equipo> lista = await _servicioApi.GetEquipos();
            return View(lista);
        }
        public async Task<IActionResult> Getequipo(int id)
        {
            Equipo equipo = null;
            ViewBag.Accion = "Nuevo equipo";
            equipo = await _servicioApi.GetEquipo(id);
            if (equipo != null)
            {
                ViewBag.Accion = "Editar equipo";
            }
            return View(equipo);
        }
        public async Task<IActionResult> Agregarequipo(EquipoDTO e)
        {
            bool respuesta = false;
            respuesta = await _servicioApi.AgregarEquipo(e);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
        public async Task<IActionResult> Editarequipo(int id, EquipoDTO e)
        {
            bool respuesta = false;
            respuesta = await _servicioApi.EditarEquipo(id, e);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
        public async Task<IActionResult> Borrarequipo(int id)
        {
            var respuesta = await _servicioApi.BorrarEquipo(id);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        public IActionResult BuscarEquipo()
        {
            return View();
        }
        public IActionResult AgregarEquipoForm()
        {
            return View();
        }
        public async Task<IActionResult> EditarEquipoForm(int id)
        {
            var equipo = await _servicioApi.GetEquipo(id);
            ViewBag.Id = equipo.Id;
            var pdto = new EquipoDTO()
            {
                Nombre = equipo.Nombre,
                Color = equipo.Color,
                Descripcion = equipo.Descripcion,
            };
            return View(pdto);
        }
        public IActionResult EliminarEquipoForm(int id, string nombre)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Id = id;
            return View();
        }
    }
}
