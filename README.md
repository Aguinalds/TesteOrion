# Documentação do Projeto - API de Produtos

## 1. Estrutura do Projeto

A estrutura do projeto é organizada em várias camadas que seguem o padrão de arquitetura em camadas. Abaixo está a descrição da estrutura de diretórios:

/TesteOrion │ ├── Controllers │ └── ProductController.cs │ ├── Services │ ├── ProductService.cs │ └── IProductService.cs │ ├── Repositories │ ├── ProductRepository.cs │ └── IProductRepository.cs │ ├── Models │ └── Product.cs │ ├── Migrations │ └── [Migrações do FluentMigrator] │ ├── Validators │ └── ProductValidator.cs │ ├── Tests │ └── ProductServiceTests.cs │ ├── Docker │ ├── docker-compose.yml │ └── Dockerfile │ └── TesteOrion.sln

