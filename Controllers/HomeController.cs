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
    public IActionResult registro(){
        ViewBag.Error="";
        return View();
    }
    public IActionResult OlvidoContraseña(){
        ViewBag.Error="";
        return View();
    }

     public IActionResult pantallaEscritor(){
        return View();
    }

    public IActionResult inicio(){
        // ViewBag.ListaLibros = BD.ObtenerLibros();
        return View();
    }

    public IActionResult listaSeguimiento(){
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

    //     [HttpPost] public IActionResult CrearUsuario(Usuario uss){
    //     Usuario us = BD.verificarnombre(uss.Username);
    //     if(us != null){
    //         ViewBag.Error = "ERROR: Usuario ya existente";
    //         return View("Login");
    //     }
    //     BD.añadirusuario(uss);
    //     ViewBag.msj = "El usuario se ha creado correctamente";
    //     return View("Login");
    // }    

   

}
