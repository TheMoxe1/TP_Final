using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(){
        ViewBag.Error="";
        return View();
    }
    public IActionResult Registrarse(){
        ViewBag.Error="";
        return View();
    }
    public IActionResult OlvidoContraseña(){
        ViewBag.Error="";
        return View();
    }
    // }
    // public IActionResult VerificarLogin(string Username,string Contraseña){
    //     if(BD.VerificarDatos(Username,Contraseña)){
    //         return RedirectToAction("pagina");
    //     }else{
    //         ViewBag.Existe=true;
    //         return View("Login");
    //     }

    // }
    // public IActionResult VerificarRegistrarse(Usuario U){

    //     if(BD.VerificarUsername(U.username)){
    //     ViewBag.Error="Ese nombre de usuario ya está en uso, elegir otro";
    //         return View("Registrarse");
    //     }else{
    //         BD.Registrarse(U);
    //         return RedirectToAction("pagina");
    //     }

    // }

}
