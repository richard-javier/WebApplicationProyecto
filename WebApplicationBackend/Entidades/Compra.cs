namespace WebApplicationBackend.Entidades
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleCompra> DetallesCompra { get; set; }
    }

    public class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
