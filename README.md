# Documentação do Projeto - API de Produtos

## 1. Estrutura do Projeto

A estrutura do projeto é organizada em várias camadas que seguem o padrão de arquitetura em camadas. Abaixo está a descrição da estrutura de diretórios:

/TesteOrion
│
├── /Banco
│   └── Context.cs
│
├── /Controllers
│   └── ProductController.cs
│
├── /Migrations
│   └── [Migrações do FluentMigrator]
│
├── /Models
│   └── Produto.cs
│
├── /Repositories
│   └── ProductRepository.cs
│   └── IProductRepository.cs
│
├── /Services
│   └── ProductService.cs
│   └── IProductService.cs
│
├── /Validators
│   └── ProductValidator.cs
│
├── Dockerfile
│
└── TesteOrion.sln

h1 2.Estrutura de Testes
/OrionTest
│
├── ProdutoTests.cs
│

