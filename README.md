# Basis API
Este repositório abriga o projeto BasisAPI, construído com .NET 8 e estruturado com base nos conceitos de Clean Architecture e Domain-Driven Design (DDD), além de utilizar Docker para simplificar a configuração e execução do ambiente.

## 🪛 Tecnologias e Padrões
* .NET 8
* SQL Server
* Clean Architecture
* Entity Framework Core
* Docker e Docker Compose
* DDD (Domain Driven Design)
* xUnit

## 👌 Pré-requisitos
* Docker
* Docker Compose

## 🏗️ Guia de como executar aplicação
1. Clonar repositório
```sh
    git clone https://github.com/DiogoEngh/BasisAPI.git
    cd BasisAPI
```

2. Executar o Docker Compose
```sh
    docker-compose up -d --build
```

3. Accessando aplicação (http://localhost:5000/swagger/index.html)

4. Executando Testes
```sh
    dotnet test --project Basis.Tests
```