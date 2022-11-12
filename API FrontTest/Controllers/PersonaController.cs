using API_FrontTest.Models;
using API_FrontTest.Models.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_FrontTest.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IServicioPersona _servicioApi;

        public PersonaController(IServicioPersona servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Persona> lista = await _servicioApi.GetPersonas();
            return View(lista);
        }
        public async Task<IActionResult> GetPersona(int id)
        {
            Persona persona = null;
            ViewBag.Accion = "Nueva Persona";
            persona = await _servicioApi.GetPersona(id);
            if (persona != null)
            {
                ViewBag.Accion = "Editar Persona";
            }
            return View(persona);
        }
        public async Task<IActionResult> AgregarPersona(PersonaDTO p)
        {
            bool respuesta = false;
            respuesta = await _servicioApi.AgregarPersona(p);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
        public async Task<IActionResult> EditarPersona(int id, PersonaDTO p)
        {
            bool respuesta = false;
            respuesta = await _servicioApi.EditarPersona(id, p);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
        public async Task<IActionResult> BorrarPersona(int id)
        {
            var respuesta = await _servicioApi.BorrarPersona(id);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        public IActionResult BuscarPersona()
        {
            return View();
        }
        public IActionResult AgregarPersonaForm()
        {
            return View();
        }
        public async Task<IActionResult> EditarPersonaForm(int id)
        {
            var persona = await _servicioApi.GetPersona(id);
            ViewBag.Id = persona.Id;
            var pdto = new PersonaDTO()
            {
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Edad = persona.Edad,
                Distrito = persona.Distrito,
                IdEquipo = persona.IdEquipo,
            };
            return View(pdto);
        }
        public IActionResult EliminarPersonaForm(int id, string nombre)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Id = id;
            return View();
        }
    }
}

