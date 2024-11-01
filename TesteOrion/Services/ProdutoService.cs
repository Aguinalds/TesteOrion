using System.Collections.Generic;
using System.Threading.Tasks;
using TesteOrion.Models;
using TesteOrion.Repositories;

namespace TesteOrion.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public Produto GetByNomeAsync(string nome)
        {
            return _produtoRepository.GetByNomeAsync(nome);
        }

        public async Task AddAsync(Produto produto)
        {
            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateAsync(Produto produto)
        {
            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }
}
