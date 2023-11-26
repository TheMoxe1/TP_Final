using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

//DESKTOP-Q07IUI0\SQLEXPRESS
public class BD{
      private static string _connectionString = @"Server=LocalHost;DataBase=IBDb;Trusted_Connection=True;";

      public static void añadirusuario(Usuario u){
        string sql = "INSERT INTO Usuarios(Nombre, Contrasena, Gmail, Email, Genero1) VALUES (@cNombre, @cContrasena, @cGmail, @cGeneroFav)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new{cUsername = u.Nombre, cContrasena = u.Contrasena, cGmail = u.Gmail, cGeneroFav = u.Genero1});
        }
    }
public static Usuario verificarUsuario(string Nombre, string Contra){
        Usuario veriUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuarios WHERE Nombre = @nombre and Contrasena = @contra";
            veriUsuario = db.QueryFirstOrDefault<Usuario>(sql, new{nombre = Nombre, contra = Contra});       
        }
        return veriUsuario;
    }

           public static Usuario verificarnombre(string Nombre){
        Usuario veriUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuarios WHERE Nombre = @nombre";
            veriUsuario = db.QueryFirstOrDefault<Usuario>(sql, new{nombre = Nombre});       
        }
        return veriUsuario;
    }
    public static void cambiarContraseña(string Nombre, string contra){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "UPDATE Usuarios SET Contrasena = @Contra WHERE Nombre = @nombre";
            db.Execute(sql, new{Contra = contra, nombre = Nombre});    
        }
    }

     public static List<Libro> enlistarLibros(){
        List<Libro> ListaLibros = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Libro";
            ListaLibros = db.Query<Libro>(sql).ToList();
        }
        return ListaLibros;
    }
public static Libro obtenerLibro(int idLibro){
Libro L = null;
using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Libro WHERE idLibro = @IdLibro";
            L = db.QueryFirstOrDefault<Libro>(sql, new{IdLibro = idLibro});
        }
    return L;
}

public static Reseñas obtenerReseñas(int idLibro){
Reseñas R = null;
using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Reseñas WHERE idLibro = @IdLibro";
            R = db.QueryFirstOrDefault<Reseñas>(sql, new{IdLibro = idLibro});
        }
    return R;
}

public static string ObtenerReseñaPorLibroPorUsuario(int idReseña, int idLibro, int idUsuario){
    string reseña = "";
    using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Testo FROM ReseñaUsuario WHERE idReseña = @IdReseña AND idLibro = @IdLibro AND idUsuario = @IdUsuario";
            reseña = db.QueryFirstOrDefault<string>(sql, new{idReseña = idReseña, IdLibro = idLibro, IdUsuario = idUsuario});;
        }
    return reseña;
}

      public static void añadirSeguimiento(int idUsuario, int idLibro){
        string sql = "INSERT INTO Seguimiento(IdLibro, IdUsuario) VALUES (@cIdLibro, @cIdUsuario, @cSeguir)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new{cIdLibro = idLibro, cIdUsuario = idUsuario, cSeguir = 1});
        }
    }
}