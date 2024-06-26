﻿using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        user.iniciarPag();
        return View();
    }
    public IActionResult VerificarUsuario(string nombre, string contra)
    {
        Console.WriteLine(nombre, contra);
        Usuario uss = BD.verificarUsuario(nombre, contra);
        if (uss == null)
        {
            ViewBag.msj = "El usuario o la contraseña son incorrectos";
            return View("index");
        }
        else
        {   
            user.cargarusuario(uss.IdUsuario);
            return RedirectToAction("inicio");
        }
    }

    public IActionResult pantallaGenero(int idGenero)
    {
        var librosDelGenero = BD.ObtenerLibrosPorGenero(idGenero); // Obtener los libros del género especificado
        ViewBag.Genero = BD.ObtenerGenero(idGenero);
        ViewBag.LibrosDelGenero = librosDelGenero;
        return View("pantallaGenero");
    }

    public IActionResult CerrarSesion()
    {

        user.cargarusuario(-1);
        return RedirectToAction("index");
    }

    public IActionResult pantallaUsuario(){

        return View("pantallaUsuario");
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
            ViewBag.msj = "ERROR: Usuario ya existente";
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
        ViewBag.NumeroAleatorio = GenerarNumeroAleatorio();
        int num1 = 35;
        int num2 = 45;
        int num3 = 22;
        ViewBag.carousel1 = BD.obtenerLibroRandom(num1);
        ViewBag.carousel2 = BD.obtenerLibroRandom(num2);
        ViewBag.carousel3 = BD.obtenerLibroRandom(num3);
        ViewBag.ListaGeneros = BD.enlistarLibrosXGenero();
        ViewBag.ListaGeneros1 = BD.enlistarLibrosXGenero();
        ViewBag.ListaGeneros2 = BD.enlistarLibrosXGenero();
        ViewBag.ListaGeneros3 = BD.enlistarLibrosXGenero();
        ViewBag.ListaGeneros4 = BD.enlistarLibrosXGenero();
        ViewBag.ListaReseñas = BD.enlistarLibrosXReseña();
        for(int x = 0; x < ViewBag.ListaGeneros.Count; x++){
            ViewBag.ListaGeneros[x].promedioPuntuacion = calcularpromedio(ViewBag.ListaGeneros[x].Reseña1, ViewBag.ListaGeneros[x].Reseña2, ViewBag.ListaGeneros[x].Reseña3, ViewBag.ListaGeneros[x].Reseña4, ViewBag.ListaGeneros[x].Reseña5, ViewBag.ListaGeneros[x].ReseñasTotales);
        }
        for(int x = 0; x < ViewBag.ListaReseñas.Count; x++){
            ViewBag.ListaReseñas[x].promedioPuntuacion = calcularpromedio(ViewBag.ListaReseñas[x].Reseña1, ViewBag.ListaReseñas[x].Reseña2, ViewBag.ListaReseñas[x].Reseña3, ViewBag.ListaReseñas[x].Reseña4, ViewBag.ListaReseñas[x].Reseña5, ViewBag.ListaReseñas[x].ReseñasTotales);
        }
        //if(ViewBag.carousel1.FotoEscritor == null){
        //    ViewBag.carousel1.FotoEscritor = "~/img/perfil-de-usuario.webp";
        //}
        //if(ViewBag.carousel2.FotoEscritor == null){
         //   ViewBag.carousel2.FotoEscritor = "~/img/perfil-de-usuario.webp";
        //}
        //if(ViewBag.carousel3.FotoEscritor == null){
         //   ViewBag.carousel3.FotoEscritor = "~/img/perfil-de-usuario.webp";
        //}
        return View();
    }   

    public double calcularpromedio(int Reseña1, int Reseña2, int Reseña3, int Reseña4, int Reseña5, int ReseñasTotales){
        
        double promedio = 0;
        List<double> ListaPromedios = new List<double>();
        double promedio1 = Reseña1 / ReseñasTotales * 100;
        ListaPromedios.Add(promedio1);
        double promedio2 = Reseña2 / ReseñasTotales * 100;
        ListaPromedios.Add(promedio2);
        double promedio3 = Reseña3 / ReseñasTotales * 100;
        ListaPromedios.Add(promedio3);
        double promedio4 = Reseña4 / ReseñasTotales * 100;
        ListaPromedios.Add(promedio4);
        double promedio5 = Reseña5 / ReseñasTotales * 100;
        ListaPromedios.Add(promedio5);
        for(int x = 0; x > ListaPromedios.Count; x++){
            if(promedio < ListaPromedios[x]){
                promedio = ListaPromedios[x];
            }
        }
        return promedio;
    }

    public IActionResult pantallaLibro(int L)
    {   
        ViewBag.Reseñas = BD.enlistarReseñas(L);
        ViewBag.Libro = BD.obtenerLibro(L);
        return View();
    }

    public List<LibrosBuscador> CargarBuscador(){
        List<LibrosBuscador> LibrosBusc = new List<LibrosBuscador>();
        LibrosBusc = BD.LibrosBuscador();
        return LibrosBusc;
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

    [HttpPost]
    public IActionResult añadirReseña(ReseñaUsuario us){
        BD.añadirReseña(us);
        return RedirectToAction("pantallaLibro", new {L = us.IdLibro});
    }

    public IActionResult eliminarReseña(int Rid, int Uid, int Lid){
        Console.WriteLine(Rid);
        BD.eliminarReseña(Rid, Uid);
        return RedirectToAction("pantallaLibro", new {L = Lid});
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
    public static int GenerarNumeroAleatorio()
    {
        Random random = new Random();
        return random.Next(1, 6);
    }
    public void BuscarGeneroLibro(int x){
        ViewBag.libroG = BD.BuscarGLibro(x);
    }





}
