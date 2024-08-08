namespace WebApplicationBackend.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEnStock { get; set; }
        public decimal Precio { get; set; }
    }
}
