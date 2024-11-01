using Microsoft.EntityFrameworkCore;
using TesteOrion.Models;

namespace TesteOrion.Banco
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
