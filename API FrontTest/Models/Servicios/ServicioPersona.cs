using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace API_FrontTest.Models.Servicios
{
    public class ServicioPersona : IServicioPersona
    {
        public static string baseUrl = string.Empty;

        public ServicioPersona()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            baseUrl = builder.GetSection("ApiSettings:baseurl").Value;
        }

        public async Task<bool> AgregarPersona(PersonaDTO pnew)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(pnew), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Persona/AgregarPersona", content);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }


        public async Task<bool> BorrarPersona(int id)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);

            var response = await cliente.DeleteAsync($"api/Persona/BorrarPersona/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }

        public async Task<bool> EditarPersona(int id, PersonaDTO pupdt)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(pupdt), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Persona/ActualizarPersona/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }

        public async Task<Persona> GetPersona(int idPersona)
        {
            Persona p = null;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var response = await cliente.GetAsync($"api/Persona/BuscarPersona/{idPersona}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Persona>(json_response);
                p = resultado;
            }
            return p;
        }

        public async Task<List<Persona>> GetPersonas()
        {
            List<Persona> lista = new List<Persona>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var response = await cliente.GetAsync("api/Persona/ObtenerTodasPersonas");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Persona>>(json_response);
                lista = resultado;
            }
            return lista;
        }
    }
}
