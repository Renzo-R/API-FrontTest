using System.Text.Json.Serialization;

namespace API_FrontTest.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public int IdEquipo { get; set; }
        public string Distrito { get; set; } = null!;
        public bool Active { get; set; }
        [JsonIgnore]
        public virtual Equipo IdEquipoNavigation { get; set; } = null!;
    }
}
