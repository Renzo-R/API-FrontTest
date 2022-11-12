namespace API_FrontTest.Models.Servicios
{
    public interface IServicioPersona
    {
        Task<List<Persona>> GetPersonas();
        Task<Persona> GetPersona(int idPersona);
        Task<bool> AgregarPersona(PersonaDTO p);
        Task<bool> EditarPersona(int id, PersonaDTO pupdt);
        Task<bool> BorrarPersona(int id);

    }
}
