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
            return View("registro");
        }
        else
        {
            BD.añadirusuario(uss);
            ViewBag.msj = "El usuario se ha creado correctamente";
            return View("inicio");
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
        ViewBag.ListaLibros = BD.enlistarLibros();
        return View();
    }

    public IActionResult verLibro(int L)
    {
        ViewBag.Libro = BD.obtenerLibro(L);
        return View("pantallaLibro");
    }
    public IActionResult pantallaLibro(int idReseña)
    {
        ViewBag.ListaReseñas = BD.obtenerReseñas(idReseña);
        return View();
    }

    public string VerReseña(int idR, int idL, int idU)
    {
        return BD.ObtenerReseñaPorLibroPorUsuario(idR, idL, idU);
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
