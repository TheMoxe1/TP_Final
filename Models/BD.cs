using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

//DESKTOP-Q07IUI0\SQLEXPRESS

//FEDE-GAMMER\SQLEXPRESS
public class BD{
      private static string _connectionString = @"Server=FEDE-GAMMER\SQLEXPRESS;DataBase=IBDb;Trusted_Connection=True;";

      public static void añadirusuario(Usuario u){
        string sql = "INSERT INTO Usuario(Nombre, Contrasena, Gmail, Genero1, Genero2, Genero3, Genero4, Genero5) VALUES (@cNombre, @cContrasena, @cGmail, @cGenero1, @cGenero2, @cGenero3, @cGenero4, @cGenero5)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new{cNombre = u.Nombre, cContrasena = u.Contrasena, cGmail = u.Gmail, cGenero1 = u.Genero1, cGenero2 = u.Genero2, cGenero3 = u.Genero3, cGenero4 = u.Genero4, cGenero5 = u.Genero5});
        }
    }
public static Usuario verificarUsuario(string Nombre, string Contra){
        Usuario veriUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuario WHERE Nombre = @nombre and Contrasena = @contra";
            veriUsuario = db.QueryFirstOrDefault<Usuario>(sql, new{nombre = Nombre, contra = Contra});       
        }
        return veriUsuario;
    }

        public static Usuario verificarnombre(string Nombre){
        Usuario veriUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuario WHERE Nombre = @nombre";
            veriUsuario = db.QueryFirstOrDefault<Usuario>(sql, new{nombre = Nombre});       
        }
        return veriUsuario;
    }
    public static void cambiarContraseña(string Nombre, string contra){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "UPDATE Usuario SET Contrasena = @Contra WHERE Nombre = @nombre";
            db.Execute(sql, new{Contra = contra, nombre = Nombre});
        }
    }

     public static List<Libro> enlistarLibrosXGenero(){
        List<Libro> ListaLibros = null;
        Random random = new Random();
        int rNumber = random.Next(0, 21);
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT L.IdLibro, L.Nombre, L.Tapa, G1.Nombre AS Genero1Nombre,G2.Nombre AS Genero2Nombre, G3.Nombre AS Genero3Nombre, G4.Nombre AS Genero4Nombre, G5.Nombre AS Genero5Nombre, L.AnoPublicacion, L.Sinopsis, R.Reseña1, R.Reseña2, R.Reseña3, R.Reseña4, R.Reseña5, R.ReseñasTotales FROM Libro L INNER JOIN Generos G1 ON L.Genero1 = G1.IdGenero LEFT JOIN Generos G2 ON L.Genero2 = G2.IdGenero LEFT JOIN Generos G3 ON L.Genero3 = G3.IdGenero LEFT JOIN Generos G4 ON L.Genero4 = G4.IdGenero LEFT JOIN Generos G5 ON L.Genero5 = G5.IdGenero INNER JOIN Reseñas R ON R.IdLibro = L.IdLibro WHERE L.Genero1= @crNumber OR L.Genero2 = @crNumber OR L.Genero3 = @crNumber OR L.Genero4 = @crNumber OR L.Genero5 = @crNumber";
            ListaLibros = db.Query<Libro>(sql, new {crNumber = rNumber}).ToList();
        }
        return ListaLibros;
    }

     public static List<Libro> enlistarLibrosXReseña(){//Tendria sentido que reciba generos o autor para filtrar pq mucho sentido no tiene agarrar todo
        List<Libro> ListaLibros = null;

        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT TOP 20 L.IdLibro, L.Nombre, L.Tapa, G1.Nombre AS Genero1Nombre,G2.Nombre AS Genero2Nombre, G3.Nombre AS Genero3Nombre, G4.Nombre AS Genero4Nombre, G5.Nombre AS Genero5Nombre, L.AnoPublicacion, L.Sinopsis, R.Reseña1, R.Reseña2, R.Reseña3, R.Reseña4, R.Reseña5, R.ReseñasTotales FROM Libro L INNER JOIN Generos G1 ON L.Genero1 = G1.IdGenero LEFT JOIN Generos G2 ON L.Genero2 = G2.IdGenero LEFT JOIN Generos G3 ON L.Genero3 = G3.IdGenero LEFT JOIN Generos G4 ON L.Genero4 = G4.IdGenero LEFT JOIN Generos G5 ON L.Genero5 = G5.IdGenero INNER JOIN Reseñas R ON R.IdLibro = L.IdLibro ORDER BY R.ReseñasTotales DESC;";
            ListaLibros = db.Query<Libro>(sql).ToList();
        }
        return ListaLibros;
    }
    
public static Libro obtenerLibro(int idLibro){
Libro L = null;
using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT L.IdLibro, L.Nombre, L.Tapa, G1.Nombre AS Genero1Nombre,G2.Nombre AS Genero2Nombre, G3.Nombre AS Genero3Nombre, G4.Nombre AS Genero4Nombre, G5.Nombre AS Genero5Nombre, A.Nombre AS NombreEscritor, A.Biografia AS BioEscritor, A.Foto AS FotoEscritor, L.AnoPublicacion, L.Sinopsis, R.Reseña1, R.Reseña2, R.Reseña3, R.Reseña4, R.Reseña5, R.ReseñasTotales FROM Libro L INNER JOIN Generos G1 ON L.Genero1 = G1.IdGenero LEFT JOIN Generos G2 ON L.Genero2 = G2.IdGenero LEFT JOIN Generos G3 ON L.Genero3 = G3.IdGenero LEFT JOIN Generos G4 ON L.Genero4 = G4.IdGenero LEFT JOIN Generos G5 ON L.Genero5 = G5.IdGenero INNER JOIN Escritor A ON A.IdEscritor = L.IdEscritor INNER JOIN Reseñas R ON R.IdLibro = L.IdLibro WHERE L.IdLibro = @cIdLibro";
            L = db.QueryFirstOrDefault<Libro>(sql, new{cIdLibro = idLibro});
        }
    return L;
}

public static LibroConAutor obtenerLibroRandom(){
LibroConAutor L = null;
 Random random = new Random();
 int rNumber = random.Next(5, 103);
using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT L.IdLibro, L.Nombre, L.Tapa, A.Nombre AS NombreEscritor, A.Biografia AS BioEscritor, A.Foto AS FotoEscritor, L.Sinopsis FROM Libro L INNER JOIN Escritor A ON A.IdEscritor = L.IdEscritor WHERE idLibro = @crNumber";
            L = db.QueryFirstOrDefault<LibroConAutor>(sql, new{crNumber = rNumber});
        }
    return L;
}

public static ReseñaUsuario obtenerReseñasUs(int idLibro){
ReseñaUsuario R = null;
using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT R.Reseña, R.Testo, U.Nombre, U.Foto FROM ReseñaUsuario INNER JOIN Usuario U ON U.IdUsuario = R.IdUsuario WHERE idLibro = @IdLibro";
            R = db.QueryFirstOrDefault<ReseñaUsuario>(sql, new{IdLibro = idLibro});
        }
    return R;
}

public static void añadirSeguimiento(int idUsuario, int idLibro){
    string sql = "INSERT INTO Seguimiento(IdLibro, IdUsuario) VALUES (@cIdLibro, @cIdUsuario)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new{cIdLibro = idLibro, cIdUsuario = idUsuario });
    }
    }
        public static List<Generos> enlistarGeneros(){
        List<Generos> ListaGeneros = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Generos";
            ListaGeneros = db.Query<Generos>(sql).ToList();
        }
        return ListaGeneros;
    }

    public static void añadirReseña(ReseñaUsuario RU){
         string sql = "INSERT INTO ReseñaUsuario(IdUsuario, IdLibro, Reseña, Testo) VALUES(@cIdUsuario, @cIdLibro, @cReseña, @cTesto)";
           using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new{ cIdUsuario = RU.IdUsuario, cIdLibro = RU.IdLibro, cReseña = RU.Reseña, cTesto = RU.Testo});
    }
    }

    public static List<ReseñaUsuario> enlistarReseñas(){
        List<ReseñaUsuario> ListaReseñas = null;
         using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM ReseñaUsuario";
            ListaReseñas = db.Query<ReseñaUsuario>(sql).ToList();
        }
        return ListaReseñas;
    }


}



//public static void EliminarSeguimiento(int idUsuario, int idLibro){
//    string sql = "DELETE * FROM Seguiminiento WHERE IdLibro = cIdLibro AND IdUsuario = cIdUsuario";
//    using(SqlConnection db = new SqlConnection(_connectionString)){
//        db.Execute(sql, new{cIdLibro = idLibro, cIdUsuario = idUsuario });
//    }
//    }
//} pq da error 