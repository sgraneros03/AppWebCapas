using Clases.Datos;
using Clases.Interfaces;
using Clases.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Clases.Datos
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Clase>> ObtenerTodasLasClases()
        {
            return await _context.Clase.ToListAsync();
        }

        public async Task<Clase> ObtenerClasePorId(int id)
        {
            return await _context.Clase.FindAsync(id);
        }

        public async Task AgregarClase(Clase clase)
        {
            await _context.Clase.AddAsync(clase);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarClase(Clase clase)
        {
            _context.Clase.Update(clase);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarClase(int id)
        {
            var clase = await _context.Clase.FindAsync(id);
            if (clase != null)
            {
                _context.Clase.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }
    }
}