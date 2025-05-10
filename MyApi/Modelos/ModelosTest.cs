namespace MyApi.Modelos
{
    public class Cliente {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class Producto {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
    public class ProductoAux
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
    }

    public class Pedido {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public List<Producto> Productos { get; set; }
    }

    public class PedidoAux
    {
        public int IdCliente { get; set; }
        public List<ProductoAux> Productos { get; set; }
    }

    public class AIRequest
    {
        public string Input { get; set; }
    }


}

