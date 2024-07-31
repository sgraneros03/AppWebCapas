using Clases.Modelos;

namespace Clases.Interfaces
{
    public interface IClaseRepository
    {
        Task<IEnumerable<Clase>> ObtenerTodasLasClases();
        Task<Clase> ObtenerClasePorId(int id);
        Task AgregarClase(Clase clase);
        Task ActualizarClase(Clase clase);
        Task EliminarClase(int id);
    }
}