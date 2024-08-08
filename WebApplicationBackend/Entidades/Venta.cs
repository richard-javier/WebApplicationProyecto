namespace WebApplicationBackend.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }

    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
