using MyApi.Modelos;
using MyApi.Repositories;

namespace MyApi.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repo;

        public ProductoService(ProductoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Producto>> GetAll() => _repo.GetAll();
        public Task<Producto> GetById(int id) => _repo.GetById(id);
        public Task<int> Insert(Producto p) => _repo.Insert(p);
        public Task<int> Update(Producto p) => _repo.Update(p);
        public Task<int> Delete(int id) => _repo.Delete(id);
    }
}
