# Documentação do Projeto - API de Produtos


## 2. Descrição das Camadas e Responsabilidades

- **Controllers**: Gerenciam as requisições HTTP e retornam respostas. O `ProductController` gerencia as operações CRUD para produtos.
  
- **Services**: Implementam a lógica de negócio. O `ProductService` encapsula operações de manipulação de produtos, garantindo o cumprimento das regras de negócio.
  
- **Repositories**: Abstraem o acesso a dados. O `ProductRepository` é responsável por realizar operações CRUD utilizando o Entity Framework Core.

- **Models**: Contêm entidades que representam os dados. O `Product` representa um produto com propriedades como `Id`, `Name`, `Price`, etc.

- **Migrations**: Contêm as migrações para criar e atualizar o esquema do banco de dados usando FluentMigrator.

- **Validators**: Implementam as validações de dados com FluentValidation. O `ProductValidator` garante que os dados atendam às regras de validação.

- **OrionTests**: Contêm os testes automatizados para garantir que a lógica de negócio funcione conforme esperado, escritos com xUnit.

## 3. Escolha de Tecnologias e Padrões de Projeto

- **ASP.NET Core**: Para construção da API, permitindo a criação de serviços web robustos.
  
- **Entity Framework Core**: ORM para facilitar a interação com o banco de dados.
  
- **FluentMigrator**: Para gerenciar migrações do banco de dados, permitindo um controle de versão eficaz.

- **FluentValidation**: Para validações de modelos de forma clara e fluente.

- **xUnit**: Framework de testes para escrever e executar testes unitários.

- **Docker e Docker Compose**: Para facilitar o desenvolvimento e a execução da aplicação em ambientes isolados.

- **Princípios SOLID**: O projeto foi desenvolvido seguindo esses princípios, garantindo modularidade e manutenção do código.

## 4. Plano de Testes

Os testes unitários foram implementados usando xUnit e cobrem os seguintes cenários:

- **CRUD de Produtos**:
  - **Create**: Verifica se um produto é criado corretamente e se as validações são aplicadas.
  - **Read**: Verifica a recuperação de um produto por ID e a lista de todos os produtos.
  - **Update**: Verifica se as atualizações em um produto são realizadas corretamente.
  - **Delete**: Verifica se um produto é removido corretamente do banco de dados.

- **Validações**: Testa todas as regras de validação no `ProductValidator`, assegurando que dados inválidos sejam rejeitados.

## 5. Como Executar o Projeto

Para executar o projeto, utilize o Docker Compose para construir e iniciar os serviços:

```bash
docker-compose --env-file .env up -d --build


