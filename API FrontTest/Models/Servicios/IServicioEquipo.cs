namespace API_FrontTest.Models.Servicios
{
    public interface IServicioEquipo
    {
        Task<List<Equipo>> GetEquipos();
        Task<Equipo> GetEquipo(int idEquipo);
        Task<bool> AgregarEquipo(EquipoDTO e);
        Task<bool> EditarEquipo(int id, EquipoDTO epdt);
        Task<bool> BorrarEquipo(int id);
    }
}
