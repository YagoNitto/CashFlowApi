### API para gerenciamento de despesas pessoais ou corporativas, utilizando **.NET 8** e seguindo **Domain Driven Design (DDD)**.

## Tecnologias

- **C# 12**, **ASP.NET Core 8**
- **Entity Framework Core 8** e **SQL Server**
- **Swagger** para documentação
- **AutoMapper**, **FluentValidation**, **FluentAssertions**
- **DDD** (camadas: API, Application, Domain, Infrastructure, Exception)
- **Geração de relatórios** em **PDF** e **Excel** (para o mês escolhido)

## Estrutura do Projeto

- **API**: Exposição dos endpoints HTTP e documentação Swagger.
- **Application**: Casos de uso, lógica de negócio e validação de dados.
- **Domain**: Entidades de domínio, regras de negócio e interfaces de repositórios.
- **Exception**: Exceções customizadas e tratamento global de erros.
- **Infrastructure**: Implementação dos repositórios e persistência de dados com **EF Core**.