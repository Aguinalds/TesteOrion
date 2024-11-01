using FluentMigrator;

namespace TesteOrion.Migrations
{
    [Migration(2024103102)]
    public class v1_CriacaoProdutos : Migration
    {
        public override void Up()
        {
            Create.Table("Produtos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(100).NotNullable()
                .WithColumn("Descricao").AsString(255).NotNullable()
                .WithColumn("Preco").AsDecimal().NotNullable()
                .WithColumn("DataCadastro").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Produtos");
        }
    }
}
