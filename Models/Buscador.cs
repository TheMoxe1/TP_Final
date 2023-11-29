using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;


[ApiController]
[Route("api/[controller]")]
public class buscadorController : ControllerBase
{
    private readonly string _connectionString = @"Server=FEDE-GAMMER\SQLEXPRESS;DataBase=IBDb;Trusted_Connection=True;";

    [HttpGet("libros")]
    public IActionResult ObtenerLibros()
    {
        List<LibrosBuscador> listaLibros;

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT IdLibro, Nombre FROM Libro";
            listaLibros = db.Query<LibrosBuscador>(sql).ToList();
        }
        return Ok(listaLibros);
    }


    
    [HttpGet("redireccionar")]
    public IActionResult redireccionar(int idLibro)
    {
        return RedirectToAction("pantallaLibro", "Home", new { L = idLibro });
    }
}
