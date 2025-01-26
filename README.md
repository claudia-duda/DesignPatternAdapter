# Design Pattern Adapter - .NET Project

Este repositório contém dois projetos que demonstram o padrão de design **Adapter** e sua ausência, organizados de forma independente para fins de comparação.

- **`ComAdapter`**: Contém a implementação do padrão Adapter.
- **`SemAdapter`**: Contém a versão sem a estrutura de Adapter.

---


Cada projeto possui sua própria `Program.cs`, sendo necessário definir qual deles será o **projeto de inicialização** para executar o código.

---

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado na máquina (versão mínima: 6.0).
- Editor de código (recomendado: Visual Studio ou Visual Studio Code).

---

## Como Executar

### 1. Usando o Visual Studio

1. **Abra a solução:**
   - Faça o clone do repositório e abra o arquivo `DesignPatternAdapter.sln` no Visual Studio.
Definir o projeto de inicialização:

2. No Solution Explorer, localize os projetos ComAdapter e SemAdapter.
 - Escolha o projeto de inicialização (Startup Project):
    - 1-SemAdapter: Clique com o botão direito no projeto SemAdapter e selecione Definir como Projeto de Inicialização.
    - 2-ComAdapter: Clique com o botão direito no projeto ComAdapter e selecione Definir como Projeto de Inicialização.
    - 
Executar o projeto:

Pressione F5 (ou clique no botão Iniciar) para executar o projeto.

### 2.  Usando CLI (.NET CLI)

Para executar os projetos, siga os passos abaixo dependendo de qual deseja rodar:

- **SemAdapter**: Para executar o projeto sem a estrutura do Adapter.
- **ComAdapter**: Para executar o projeto com a estrutura do Adapter.

### Passos

1. **Defina o diretório do projeto:**

   - Para **SemAdapter**:
     ```bash
     cd SemAdapter
     ```

   - Para **ComAdapter**:
     ```bash
     cd ComAdapter
     ```

2. **Execute o projeto:**

   - Para **SemAdapter**:
     ```bash
     dotnet run
     ```

   - Para **ComAdapter**:
     ```bash
     dotnet run
     ```


