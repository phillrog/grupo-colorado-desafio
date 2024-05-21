[![Build-Desafio](https://github.com/phillrog/grupo-colorado-desafio/actions/workflows/build.yml/badge.svg)](https://github.com/phillrog/grupo-colorado-desafio/actions/workflows/build.yml)

# Sumário
<details>
<summary><b>(click para expandir)</b></summary>
<!-- MarkdownTOC -->

1. [Objetivo:](#obj)
2. [Aplicação ASP.NET Core .NET 8.0:](#appnet)
3. [Arquitetura:](#arquitetura)
4. [Padrões de projeto:](#padroesprojeto)
5. [Boa práticas de Desenvolvimento:](#boaspraticas)
6. [Tecnologias:](#tecnologias)
7. [Biliotecas Javascript:](#bibliotecas)
8. [Técnicas:](#tecnicas)
9. [Migrations:](#migrations)
   1. [9.1 Seed:](#seed)
   1. [9.2 Client.Infrastructure:](#infra)
   1. [9.3 Client.Web:](#web)
10. [Projeto:](#projeto)
11. [Resultado:](#resultado)
     1. [11.1 Swagger:](#resultado_1)
     1. [11.2 Home:](#resultado_2)
     1. [11.3 Área do Cliente:](#resultado_3)
     1. [11.4 Mensagens:](#resultado_4)
     1. [11.5 Login:](#resultado_5)
12. [Versão com Docker](#docker)
<!-- /MarkdownTOC -->
</details>


<a id="obj"></a>
# 👉 1 - Objetivo:
Criar um CRUD cadastro de cliente ASP .NET Core. ⭐

<a id="appnet"></a>
# 💻 2 - Aplicação ASP.NET Core .NET 8.0:
- Foram criados 3 aplicações ASP .NET Core:
  - Razor Pages - Web
  - Core API - API Clientes
  - Core API - API Gateway

<a id="arquitetura"></a>
# 🏛️ 3 - Arquitetura:
- Web - MVC
- API Clientes - CQRS com conceitos de DDD

<a id="padroesprojeto"></a>
# ⚙️ 4 - Padrões de projeto:
- Factory Method
- Mediator

<a id="boaspraticas"></a>
# 🎓 5 - Boa práticas de Desenvolvimento:
- Code first 
- SOLID
- KISS
- DRY
- Cache

<a id="tecnologias"></a>
# 🤖 6 - Tecnologias:
- .NET 8.0
- .NET Core Native DI
- ASP.NET Core Razor Pages
- ASP.NET WebApi Core
- ASP.NET Identity Core
- FluentValidator
- MediatR
- AutoMapper
- Swagger UI
- Ardalis.GuardClauses
- Entity Framework Core 8.0.5
- MS Sql Server
- Ocelot

<a id="bibliotecas"></a>
# ₊⊹ 7 - Biliotecas Javascript:
- jQuery
- Bootstrap
- toastry

<a id="tecnicas"></a>
# 👀 8 - Técnicas:
- Parallax
- IoC
- Closures Module Pattern
- ajax
- modal confirmação
- mensagens para usuários
- paginação
- pesquisa e ordenação em table

<a id="migrations"></a>
# 🔎 9 - Migrations:

<a id="seed"></a>
### 💥 9.1 - Seed:
Usuário: admin@teste.com.br
Senha: Admin123#

<a id="infra"></a>
### 💥 9.2 - Client.Infrastructure:
Migrations relacionado as tabelas cliente, telefone

```dotnet ef database update --startup-project .\src\Client.Api --project .\src\Client.Infrastructure ```

<a id="web"></a>
### 💥 9.3 - Client.Web:
Migrations relacionado ao Identity

```dotnet ef database update --startup-project .\src\Client.Web --project .\src\Client.Web ```

<a id="projeto"></a>
# 🔨 10 - Projeto
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/88204323-4476-4ee8-a9b6-8f88c5ffc865)

<a id="resultado"></a>
# 💎 11 - Resultado

<a id="resultado_1"></a>
### 11.1 - Swagger

![doc1](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/96ba93d2-66e8-4ca6-80b9-6f631dfb0c91)

<a id="resultado_2"></a>
### 11.2 - Home

![doc2](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/24b67584-ba7a-4a8d-99a3-6873c8741121)

<a id="resultado_3"></a>
### 11.3 - Área Clientes
Index 
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/5aa133f3-0a23-4163-9954-8ed916d45250)

Novo Cadastro
![doc3](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/e073d333-7a02-4bcc-b973-876921654fff)


Detalhes
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/ccef9f20-a1ec-460a-8219-f8ef49a23aea)

Edição
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/8532b49f-411b-4eb6-93c0-51f9654936ce)

Exclusão

![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/5600d903-270b-47a7-ab16-87cd89e46a7d)

<a id="resultado_4"></a>
# 11.4 - Mensagens
Dados
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/4b64fb44-c5f8-4544-b127-ab440a74ccc7)


Telefones
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/98da6afb-0b9e-4165-a950-a8ee5a3a15be)
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/03c03070-5e7e-46f0-bb4e-eb84cfe7ab80)

404
![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/25837c05-e15f-4ed6-b512-3c9b2ebced26)

<a id="resultado_5"></a>
### 11.5 - Login

![image](https://github.com/phillrog/grupo-colorado-desafio/assets/8622005/1792fa68-f9eb-46ae-a0dc-ec91a36feca6)

<a id="docker"></a>
# ☕ 12 - Versão com Docker

[Clique aqui no Link para acessar a branch](https://github.com/phillrog/grupo-colorado-desafio/tree/versao-docker)
