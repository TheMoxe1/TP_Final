public class user{
    public static int IdUsuario{get; set;}

    public static string Username{get; set;}

    public static void iniciarPag(){
        IdUsuario = -1;
        
    }
    public static void cargarusuario(int cidUsuario){
        IdUsuario = cidUsuario;
        Username = BD.cargar(cidUsuario);
    }
}