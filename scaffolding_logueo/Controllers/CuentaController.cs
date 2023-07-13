using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace scaffolding_logueo.Controllers
{
    public class CuentaController: Controller
    {   
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public CuentaController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim ){
            _userManager = um;
            _signInManager = sim;
        }

        public IActionResult Registro(){
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string correo, string usuario, string password, string password2){
            if(password != password2){
                ModelState.AddModelError("password", "Las contraseñas no coinciden");
                return View();
            }
            var identityUser = new IdentityUser(usuario);
            identityUser.Email = correo;
            var result = _userManager.CreateAsync(identityUser, password).Result;
            
            if(result.Succeeded){
                return RedirectToAction("Index", "Home");
            }
            foreach(var error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password){
            var result = _signInManager.PasswordSignInAsync(usuario, password, false, false).Result;
            if(result.Succeeded){
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("usuario" , "Usuario o contraseña incorrectos");

            return View();
        }

        public IActionResult OpcionesAdmin(){
            return View();
        }

        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}