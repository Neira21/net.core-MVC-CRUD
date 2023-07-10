using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class AlumnoController : Controller
    {
        private AplicationContext _context;

        public AlumnoController( AplicationContext context){
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult> Index(){
            return _context.Alumnos != null ? 
            View(await _context.Alumnos.ToListAsync()) :
            Problem ("No se encontraron alumnos");
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<ActionResult> Detalle(int? id){
            if(id == null || _context.Alumnos == null ){
                return NotFound();
            }
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(p => p.Id == id);
            if(alumno == null){
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Alumno alumno){
            if(ModelState.IsValid){
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int? id){
            if(id == null || _context.Alumnos == null ){
                return NotFound();
            }
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(p => p.Id == id);
            if(alumno == null){
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(int id, Alumno alumno){
            if(id != alumno.Id){
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Update(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        public IActionResult Eliminar(int? id){
            if(id == null){
                return NotFound();
            }
            var alumno = _context.Alumnos.FirstOrDefault(m => m.Id == id);
            if(alumno == null){
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}