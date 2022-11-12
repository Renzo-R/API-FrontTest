namespace API_FrontTest.Models
{
    public class PersonaDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public int IdEquipo { get; set; }
        public string Distrito { get; set; } = null!;
    }
}
