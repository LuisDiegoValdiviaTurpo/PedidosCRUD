using MyApi.Modelos;
using MyApi.Repositories;

namespace MyApi.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepo;
        private readonly ProductoRepository _productoRepo;

        public PedidoService(PedidoRepository pedidoRepo, ProductoRepository productoRepo)
        {
            _pedidoRepo = pedidoRepo;
            _productoRepo = productoRepo;
        }

        public async Task<int> CrearPedido(PedidoAux pedido)
        {

            Pedido pedidoDB = new Pedido();
            pedidoDB.Productos = new List<Producto>();
            double total = 0;

            foreach (ProductoAux producto in pedido.Productos)
            {
                Producto dbProducto = await _productoRepo.GetById(producto.Id);
                if (dbProducto == null)
                    throw new Exception($"El producto {producto.Id} no existe");
                else if (dbProducto.Stock < 1 || dbProducto.Stock < producto.Cantidad)
                    throw new Exception($"No hay stock suficiente para el producto {dbProducto.Nombre}");
                else
                {
                    total += dbProducto.Precio * producto.Cantidad;
                    pedidoDB.Productos.Add(dbProducto);
                }
            }

            pedidoDB.IdCliente = pedido.IdCliente;
            pedidoDB.Fecha = DateTime.UtcNow;
            pedidoDB.Total = total;

            int idPedido = await _pedidoRepo.InsertPedido(pedidoDB);

            foreach (var producto in pedido.Productos)
            {
                await _pedidoRepo.InsertProductoPedido(idPedido, producto.Id, 1);
                await _productoRepo.DescontarStock(producto.Id, 1);
            }

            return idPedido;
        }
    }
}
