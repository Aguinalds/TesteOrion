using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteOrion.Banco;
using TesteOrion.Models;
using TesteOrion.Repositories;

namespace OrionTest
{
    public class ProdutoTests : IDisposable
    {
        private readonly Context _context;
        private readonly ProdutoRepository _repository;

        public ProdutoTests()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "TesteOrionDatabase")
                .Options;

            _context = new Context(options);
            _repository = new ProdutoRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetAllAsync_RetornarTodosOsProdutos()
        {
            var produto1 = new Produto
            {
                Id = 1,
                Nome = "Produto 1",
                Descricao = "Descrição 1",
                Preco = 10,
                DataCadastro = DateTime.Now
            };
            var produto2 = new Produto
            {
                Id = 2,
                Nome = "Produto 2",
                Descricao = "Descrição 2",
                Preco = 20,
                DataCadastro = DateTime.Now
            };

            await _repository.AddAsync(produto1);
            await _repository.AddAsync(produto2);
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_RetornarProdutoExistente()
        {
            var produto = new Produto { Id = 1, Nome = "Produto 1", Descricao = "Descrição 1", Preco = 10.0m, DataCadastro = DateTime.Now };
            await _repository.AddAsync(produto);
            await _context.SaveChangesAsync();

            var result = await _repository.GetByIdAsync(produto.Id);

            Assert.NotNull(result);
            Assert.Equal("Produto 1", result.Nome);
        }

        [Fact]
        public async Task AddAsync_AdicionarProdutoComSucesso()
        {
            var produto = new Produto { Nome = "Produto 2", Descricao = "Descrição 2", Preco = 20.0m, DataCadastro = DateTime.Now };

            await _repository.AddAsync(produto);

            var resultado = await _repository.GetByIdAsync(produto.Id);
            Assert.NotNull(resultado);
            Assert.Equal("Produto 2", resultado.Nome);
        }

        [Fact]
        public async Task UpdateAsync_AtualizarProdutoExistente()
        {
            var produtoExistente = new Produto { Id = 1, Nome = "Produto 1", Descricao = "Descrição 1", Preco = 10.0m, DataCadastro = DateTime.Now };
            await _repository.AddAsync(produtoExistente);
            await _context.SaveChangesAsync();

            var produtoAtualizado = new Produto { Id = 1, Nome = "Produto Atualizado", Descricao = "Descrição Atualizada", Preco = 15.0m, DataCadastro = DateTime.Now };

            await _repository.UpdateAsync(produtoAtualizado);

            var resultado = await _repository.GetByIdAsync(produtoAtualizado.Id);
            Assert.NotNull(resultado);
            Assert.Equal("Produto Atualizado", resultado.Nome);
        }

        [Fact]
        public async Task DeleteAsync_RemoverProdutoExistente()
        {
            var produto = new Produto { Id = 1, Nome = "Produto 1", Descricao = "Descrição 1", Preco = 10.0m, DataCadastro = DateTime.Now };
            await _repository.AddAsync(produto);
            await _context.SaveChangesAsync();

            await _repository.DeleteAsync(produto.Id);

            var resultado = await _repository.GetByIdAsync(produto.Id);
            Assert.Null(resultado);
        }
    }
}
