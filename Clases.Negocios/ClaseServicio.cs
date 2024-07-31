using Clases.Interfaces;
using Clases.Modelos;

namespace Clases.Negocios
{
    public class ClaseServicio
    {
        private readonly IClaseRepository _claseRepository;

        public ClaseServicio(IClaseRepository claseRepository)
        {
            _claseRepository = claseRepository;
        }

        public async Task<IEnumerable<Clase>> ObtenerTodasLasClases()
        {
            return await _claseRepository.ObtenerTodasLasClases();
        }

        public async Task<Clase> ObtenerClasePorId(int id)
        {
            return await _claseRepository.ObtenerClasePorId(id);
        }

        public async Task AgregarClase(Clase clase)
        {
            await _claseRepository.AgregarClase(clase);
        }

        public async Task ActualizarClase(Clase clase)
        {
            await _claseRepository.ActualizarClase(clase);
        }

        public async Task EliminarClase(int id)
        {
            await _claseRepository.EliminarClase(id);
        }
    }
}