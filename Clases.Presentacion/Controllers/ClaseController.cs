
using Clases.Modelos;
using Clases.Negocios;
using Microsoft.AspNetCore.Mvc;
namespace Clases.Presentacion.Controllers
{
    public class ClaseController : Controller
    {
        private readonly ClaseServicio _claseServicio;

        public ClaseController(ClaseServicio claseServicio)
        {
            _claseServicio = claseServicio;
        }

        public async Task<IActionResult> Index()
        {
            var clases = await _claseServicio.ObtenerTodasLasClases();
            return View("Index", clases);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Clase clase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _claseServicio.AgregarClase(clase);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al agregar la clase: " + ex.Message);
                }
            }
            return View(clase);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _claseServicio.ObtenerClasePorId(id.Value);
            if (clase == null)
            {
                return NotFound();
            }

            return View("Edit", clase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Clase ClaseEditada)
        {
            if (id != ClaseEditada.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _claseServicio.ActualizarClase(ClaseEditada);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar la clase: " + ex.Message);
                }
            }

            return View(ClaseEditada);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _claseServicio.ObtenerClasePorId(id.Value);
            if (clase == null)
            {
                return NotFound();
            }

            return View("Details", clase);
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _claseServicio.EliminarClase(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
