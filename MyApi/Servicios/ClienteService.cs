using MyApi.Modelos;
using MyApi.Repositories;

namespace MyApi.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repo;

        public ClienteService(ClienteRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Cliente>> GetAll() => _repo.GetAll();
        public Task<Cliente> GetById(int id) => _repo.GetById(id);
        public Task<int> Insert(Cliente c) => _repo.Insert(c);
        public Task<int> Update(Cliente c) => _repo.Update(c);
        public Task<int> Delete(int id) => _repo.Delete(id);
    }
}
