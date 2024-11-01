using FluentValidation;
using TesteOrion.Models;
using TesteOrion.Services;

namespace TesteOrion.Validations
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        private readonly IProdutoService _produtoService;

        public ProdutoValidator(IProdutoService produtoService)
        {
            _produtoService = produtoService;


            RuleFor(produto => produto.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100).WithMessage("O Nome pode ter no máximo 100 caracteres.");

            RuleFor(produto => produto.Preco)
                .GreaterThan(0).WithMessage("O Preço deve ser maior que zero.")
                .NotEmpty().WithMessage("O Preço é obrigatório.");

            RuleFor(produto => produto)
            .Must(produto => !NomeJaExiste(produto.Nome, produto.Id))
            .WithMessage("O Nome já existe.");
        }

        private bool NomeJaExiste(string nome, int id)
        {
            var produto = _produtoService.GetByNomeAsync(nome);
            if (produto == null)
                return false;
            if (produto.Id == id)
                return false;
            else                    
            return true;
        }

    }
}
