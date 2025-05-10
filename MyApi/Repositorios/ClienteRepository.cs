using Dapper;
using MyApi.Modelos;
using MyApi.Data;

namespace MyApi.Repositories
{
    public class ClienteRepository
    {
        private readonly DbContextDapper _db;

        public ClienteRepository(DbContextDapper db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<Cliente>("SELECT * FROM Clientes");
        }

        public async Task<Cliente> GetById(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Cliente>("SELECT * FROM Clientes WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> Insert(Cliente cliente)
        {
            using var conn = _db.CreateConnection();
            var sql = "INSERT INTO Clientes (Nombre, Correo, FechaNacimiento) VALUES (@Nombre, @Correo, @FechaNacimiento)";
            return await conn.ExecuteAsync(sql, cliente);
        }

        public async Task<int> Update(Cliente cliente)
        {
            using var conn = _db.CreateConnection();
            var sql = "UPDATE Clientes SET Nombre = @Nombre, Correo = @Correo, FechaNacimiento = @FechaNacimiento WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, cliente);
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.ExecuteAsync("DELETE FROM Clientes WHERE Id = @Id", new { Id = id });
        }
    }
}
