# Customer API – .NET Minimal API + SQLite

API simples para cadastro de clientes, desenvolvida com **.NET Minimal API**, **Entity Framework Core** e **SQLite**.

Cada cliente possui:
- **Nome**
- **Email** (obrigatório, válido e único)

---

## 🚀 Tecnologias Utilizadas

### 🔹 .NET Minimal API
- Abordagem moderna e leve para criação de APIs
- Menos boilerplate que MVC
- Ideal para microserviços e APIs REST simples
- Excelente performance

### 🔹 Entity Framework Core
- ORM oficial da Microsoft
- Facilita o acesso e manipulação da base de dados
- Suporte a migrations
- Código mais limpo e seguro

### 🔹 SQLite
- Base de dados leve e embutida
- Não requer servidor
- Ideal para projetos pequenos, testes e protótipos
- Fácil de versionar e distribuir

---

## 📦 Requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET SDK 7.0 ou superior](https://dotnet.microsoft.com/)
- Git (opcional, para clonar o repositório)

---

## ▶️ Como rodar o projecto

### 1 Clonar o repositório
```bash
git clone https://github.com/seu-usuario/customer-api.git
cd customer-api
````
### 2 Restaurar as dependências
```bash

dotnet restore
````
### 3 Inicializar o Projecto
```bash

dotnet tool install --global dotnet-ef


dotnet ef migrations add InitialCreate


dotnet ef database update


dotnet run
````

### A API ficará disponível em
```bash
http://localhost:5000
````
### Endpoint disponível: **POST** */customers*

```json
{
  "name": "Elton",
  "email": "elton@example.com"
}
````
