using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteOrion.Banco;
using TesteOrion.Models;

namespace TesteOrion.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public Produto GetByNomeAsync(string nome)
        {
            return _context.Produtos
                .Where(p => p.Nome == nome)
                .FirstOrDefault();
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(produto.Id);
            if (produtoExistente != null)
            {
                _context.Entry(produtoExistente).CurrentValues.SetValues(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
