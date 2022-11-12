using System;
using System.Collections.Generic;

namespace API_FrontTest.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Color { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
