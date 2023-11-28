using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult VerificarUsuario(string nombre, string contra)
    {
        Console.WriteLine(nombre, contra);
        Usuario uss = BD.verificarUsuario(nombre, contra);
        if (uss == null)
        {
            ViewBag.Error = "El usuario o la contraseña son incorrectos";
            return View("index");
        }
        else
        {
            ViewBag.Usuario = uss;
            return View("inicio");
        }
    }
    public IActionResult registro()
    {
        ViewBag.Generos = BD.enlistarGeneros();
        ViewBag.Error = "";
        return View();
    }
    [HttpPost]
    public IActionResult CrearUsuario(Usuario uss)
    {
        Usuario us = BD.verificarnombre(uss.Nombre);
        if (us != null)
        {
            ViewBag.Error = "ERROR: Usuario ya existente";
            return RedirectToAction("registro");
        }
        else
        {
            BD.añadirusuario(uss);
            ViewBag.msj = "El usuario se ha creado correctamente";
            return View("index");
        }
    }
    public IActionResult olvideContraseña(string nombre, string contra)
    {
        Usuario uss = BD.verificarnombre(nombre);
        if (uss == null)
        {
            ViewBag.Error = "Este usuario no existe";
            return View("olvideContraseña");
        }
        else
        {
            BD.cambiarContraseña(nombre, contra);
            ViewBag.msj = "Se cambio la contraseña correctamente";
            return View("inicio");

        }

    }

    public IActionResult inicio()
    {
        ViewBag.carousel1 = BD.obtenerLibroRandom();
        ViewBag.carousel2 = BD.obtenerLibroRandom();
        ViewBag.carousel3 = BD.obtenerLibroRandom();
        ViewBag.ListaGeneros = BD.enlistarLibrosXGenero();
        ViewBag.ListaReseñas = BD.enlistarLibrosXReseña();
        if(ViewBag.carousel1.FotoEscritor == null){
            ViewBag.carousel1.FotoEscritor = "~/img/perfil-de-usuario.webp";
        }
        if(ViewBag.carousel2.FotoEscritor == null){
            ViewBag.carousel2.FotoEscritor = "~/img/perfil-de-usuario.webp";
        }
        if(ViewBag.carousel3.FotoEscritor == null){
            ViewBag.carousel3.FotoEscritor = "~/img/perfil-de-usuario.webp";
        }
        return View();
    }

    public IActionResult pantallaLibro (int L)
    {
        ViewBag.Libro = BD.obtenerLibro(L);
        return View();
    }


    public ReseñaUsuario VerReseña(int idL)
    {
        return BD.obtenerReseñasUs(idL); 
    }
    public IActionResult listaSeguimiento()
    {
        return View();
    }

    [HttpPost]
    public IActionResult añadirSeguimiento(int idUsuario, int idLibro)
    {
        BD.añadirSeguimiento(idUsuario, idLibro);
        return RedirectToAction("pantallaLibro");
    }

    public IActionResult pantallaEscritor()
    {

        return View();
    }

    public IActionResult ayuda()
    {
        // ViewBag.ListaLibros = BD.ObtenerLibros();
        return View();
    }









}
