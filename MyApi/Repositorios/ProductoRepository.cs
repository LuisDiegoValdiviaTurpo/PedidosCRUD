using Dapper;
using MyApi.Data;
using MyApi.Modelos;

namespace MyApi.Repositories
{
    public class ProductoRepository
    {
        private readonly DbContextDapper _db;

        public ProductoRepository(DbContextDapper db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<Producto>("SELECT * FROM Productos");
        }

        public async Task<Producto> GetById(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Producto>("SELECT * FROM Productos WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> Insert(Producto producto)
        {
            using var conn = _db.CreateConnection();
            var sql = "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)";
            return await conn.ExecuteAsync(sql, producto);
        }

        public async Task<int> Update(Producto producto)
        {
            using var conn = _db.CreateConnection();
            var sql = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, producto);
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.ExecuteAsync("DELETE FROM Productos WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> DescontarStock(int idProducto, int cantidad)
        {
            using var conn = _db.CreateConnection();
            var sql = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE Id = @IdProducto AND Stock >= @Cantidad";
            return await conn.ExecuteAsync(sql, new { IdProducto = idProducto, Cantidad = cantidad });
        }
    }
}
