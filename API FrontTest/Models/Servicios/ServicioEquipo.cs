using Newtonsoft.Json;
using System.Text;

namespace API_FrontTest.Models.Servicios
{
    public class ServicioEquipo : IServicioEquipo
    {
        public static string baseUrl = string.Empty;

        public ServicioEquipo()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            baseUrl = builder.GetSection("ApiSettings:baseurl").Value;
        }

        public async Task<bool> AgregarEquipo(EquipoDTO pnew)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(pnew), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Equipo/AgregarEquipo", content);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }


        public async Task<bool> BorrarEquipo(int id)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);

            var response = await cliente.DeleteAsync($"api/Equipo/BorrarEquipo/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }

        public async Task<bool> EditarEquipo(int id, EquipoDTO pupdt)
        {
            bool result = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(pupdt), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Equipo/ActualizarEquipo/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                result = true;
            }
            return result;
        }

        public async Task<Equipo> GetEquipo(int id)
        {
            Equipo e = null;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var response = await cliente.GetAsync($"api/Equipo/BuscarEquipo/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Equipo>(json_response);
                e = resultado;
            }
            return e;
        }

        public async Task<List<Equipo>> GetEquipos()
        {
            List<Equipo> lista = new List<Equipo>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            var response = await cliente.GetAsync("api/Equipo/ObtenerTodosEquipos");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Equipo>>(json_response);
                lista = resultado;
            }
            return lista;
        }
    }
}
