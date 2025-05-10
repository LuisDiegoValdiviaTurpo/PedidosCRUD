using Dapper;
using MyApi.Data;
using MyApi.Modelos;

namespace MyApi.Repositories
{
    public class PedidoRepository
    {
        private readonly DbContextDapper _db;

        public PedidoRepository(DbContextDapper db)
        {
            _db = db;
        }

        public async Task<int> InsertPedido(Pedido pedido)
        {
            using var conn = _db.CreateConnection();
            var sql = @"INSERT INTO Pedidos (IdCliente, Fecha, Total)
                        VALUES (@IdCliente, @Fecha, @Total);
                        SELECT LAST_INSERT_ID();";

            return await conn.ExecuteScalarAsync<int>(sql, pedido);
        }

        public async Task InsertProductoPedido(int idPedido, int idProducto, int cantidad)
        {
            using var conn = _db.CreateConnection();
            var sql = "INSERT INTO PedidoProductos (IdPedido, IdProducto, Cantidad) VALUES (@IdPedido, @IdProducto, @Cantidad)";
            await conn.ExecuteAsync(sql, new { IdPedido = idPedido, IdProducto = idProducto, Cantidad = cantidad });
        }
    }
}
