public class Usuario{
    public static int IdUsuario{get;set;}
    public string Nombre{get;set;}
    public string Contrasena{get;set;}

    public string Gmail {get; set;}
    public int Genero1 {get; set;}
    public int Genero2 {get; set;}
    public int Genero3 {get; set;}
    public int Genero4 {get; set;}
    public int Genero5 {get; set;}

    public static void iniciarPag(){
        IdUsuario = -1;
    }
    public static void cargarusuario(int cidUsuario){
        IdUsuario = cidUsuario;
    }
}