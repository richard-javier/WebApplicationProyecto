namespace WebApplicationBackend.Entidades
{
    public class ListaRegistros
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }  // Fecha de nacimiento
        public int Age { get; set; }           // Edad
    }
}
