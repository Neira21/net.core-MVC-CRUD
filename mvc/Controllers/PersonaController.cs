using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class PersonaController : Controller
    {
        private UsuarioContext _context;
        public PersonaController(UsuarioContext context)
        {
            _context = context;
        }

        //Get Personas
        public async Task<ActionResult> Index(){
            return _context.Personas != null ? 
            View(await _context.Personas.ToListAsync()) :
            Problem ("No se encontraron personas");
        }

        //Get Personas/Crear
        public IActionResult Create()
        {
            return View();
        }     

        //Post Personas/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Persona persona){
            
            if(ModelState.IsValid){
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }
        
        //Get Personas/Editar/1
        public async Task<ActionResult> Edit(int? id){
            if(id == null || _context.Personas == null ){
                return NotFound();
            }
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
            if(persona == null){
                return NotFound();
            }
            return View(persona);
        }

        //Post Personas/Editar/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Persona persona){
            if(id != persona.Id){
                return NotFound();
            }
            if(ModelState.IsValid){
                try{
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if(!PersonaExists(persona.Id)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }


        //Get Personas/Detalles/1
        public async Task<ActionResult> Details(int? id){
            if(id == null || _context.Personas == null ){
                return NotFound();
            }
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
            if(persona == null){
                return NotFound();
            }
            return View(persona);
        }

        //Get Personas/Eliminar/1
        public async Task<ActionResult> Delete (int? id){
            if(id == null || _context.Personas == null ){
                return NotFound();
            }
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
            if(persona == null){
                return NotFound();
            }
            return View(persona);
        }

        //Post Personas/Eliminar/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id){
            var persona = await _context.Personas.FindAsync(id);
            if(persona == null){
                return NotFound();
            }
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id){
            return _context.Personas.Any(p => p.Id == id);
        }
        
    }
}