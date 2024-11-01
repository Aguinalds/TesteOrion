# API de Produtos

## Descrição do Projeto

Este projeto é uma API para gerenciar um CRUD de produtos, implementada em ASP.NET Core. Ele segue os princípios SOLID e utiliza o Entity Framework Core para interações com o banco de dados, juntamente com FluentMigrator para gerenciamento de migrações e FluentValidation para validação de dados.

## Instruções para Configurar e Executar o Projeto Localmente

## 1. Clone o repositório.

   git clone https://github.com/Aguinalds/TesteOrion.git

## 2. Como executar o projeto Localmente

  -**Primeiro**: Mudar o appsettings.json do projeto para apontar para seu banco local e não para imagem docker.

  -**Segundo**: Criar o banco de dados local.
  
  -**Terceiro**: "dotnet run -p TesteOrion/TesteOrion.csproj" para rodar a API ou "dotnet test" para rodar os Testes.

## 3. Como executar as migrations

  -**Primeiro**: Criar sua primeira migration na pasta Migrations usando FluentMigrator.

  -**Segundo**: Configurar na Statup a inicialização do FluentMigrator.

  -**Terceiro**: Criar o banco de dados conforme o nome que você deixou no appsettings.json.

## 4. Como fazer o pull das images docker.

  -**Primeiro**: Rodar o comando "docker pull aguinalds/testeorion:latest" para pegar a imagem da API.

  -**Segundo**:  Rodar o comando "docker pull aguinalds/testeorion-tests" para pegar a imagem dos Testes.

  -**Terceiro**: Rodar o comando "docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest" para baixar a imagem  Sql e configurar o banco(A senha e a porta se forem alteradas tem que alterar no appsettings.json também.

  -**Quarto**:  Rodar o comando "docker-compose --env-file .env up -d --build" para subir o container(O banco precisa ser criado na Imagem que você acabou de subir).

## 5. Descrição das Camadas e Responsabilidades

- **Controllers**: Gerenciam as requisições HTTP e retornam respostas. O `ProductController` gerencia as operações CRUD para produtos.
  
- **Services**: Implementam a lógica de negócio. O `ProductService` encapsula operações de manipulação de produtos, garantindo o cumprimento das regras de negócio.
  
- **Repositories**: Abstraem o acesso a dados. O `ProductRepository` é responsável por realizar operações CRUD utilizando o Entity Framework Core.

- **Models**: Contêm entidades que representam os dados. O `Product` representa um produto com propriedades como `Id`, `Name`, `Price`, etc.

- **Migrations**: Contêm as migrações para criar e atualizar o esquema do banco de dados usando FluentMigrator.

- **Validators**: Implementam as validações de dados com FluentValidation. O `ProductValidator` garante que os dados atendam às regras de validação.

- **OrionTests**: Contêm os testes automatizados para garantir que a lógica de negócio funcione conforme esperado, escritos com xUnit.

## 6. Escolha de Tecnologias e Padrões de Projeto

- **ASP.NET Core**: Para construção da API, permitindo a criação de serviços web robustos.
  
- **Entity Framework Core**: ORM para facilitar a interação com o banco de dados.
  
- **FluentMigrator**: Para gerenciar migrações do banco de dados, permitindo um controle de versão eficaz.

- **FluentValidation**: Para validações de modelos de forma clara e fluente.

- **xUnit**: Framework de testes para escrever e executar testes unitários.

- **Docker e Docker Compose**: Para facilitar o desenvolvimento e a execução da aplicação em ambientes isolados.

## 7. Plano de Testes

Os testes unitários foram implementados usando xUnit e cobrem os seguintes cenários:

- **CRUD de Produtos**:
  - **Create**: Verifica se um produto é criado corretamente e se as validações são aplicadas.
  - **Read**: Verifica a recuperação de um produto por ID e a lista de todos os produtos.
  - **Update**: Verifica se as atualizações em um produto são realizadas corretamente.
  - **Delete**: Verifica se um produto é removido corretamente do banco de dados.

- **Validações**: Testa todas as regras de validação no `ProductValidator`, assegurando que dados inválidos sejam rejeitados.



