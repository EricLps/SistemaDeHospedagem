# Documentação do Sistema de Hospedagem Simplificado 🏨
## 1. Introdução
Este documento descreve um sistema de console básico desenvolvido em C# para gerenciar reservas de hospedagem. O objetivo principal é demonstrar a aplicação de conceitos de Programação Orientada a Objetos (POO) 🧠, como classes, propriedades, construtores, listas e métodos, além de lógica de negócios como cálculo de valores e aplicação de descontos.💲

**Visão Futura:** Este sistema é a fundação para uma aplicação mais robusta. Posteriormente, ele será expandido para incluir um gerenciamento completo de quartos, que permitirá cadastrar, consultar, atualizar e excluir quartos 🛌, além de outras funcionalidades relacionadas ao controle de ocupação e disponibilidade do hotel.

## 2. Arquitetura do Projeto
O projeto está organizado em um aplicativo de console **.NET**, utilizando um namespace para as classes de modelo que representam as entidades do negócio.

- **Linguagem**: C# 💻

- **Framework**: .NET

- **Tipo de Projeto**: Console Application

## 3. Estrutura de Classes
O sistema é composto pelas seguintes classes principais, localizadas no namespace ``SistemaHospedagem.Models``:

### 3.1. ``Pessoa`` 👨‍👩‍👧‍👦
Representa um hóspede individual.

- **Propriedades**:

  - ``Nome``(string): Nome do hóspede.

  - ``Sobrenome``(string): Sobrenome do hóspede.

  - ``NomeCompleto``(string - propriedade somente leitura): Concatena Nome e Sobrenome.

  - **Construtor**: ``Pessoa(string nome, string sobrenome)`` - Inicializa o nome e sobrenome do hóspede.

### 3.2. ``Suite`` 🏨
Define os detalhes de uma suíte de hotel.

- **Propriedades**:

    - ``TipoSuite``(string): Descrição do tipo da suíte (ex: "Premium", "Standard").

    - ``Capacidade``(int): Número máximo de hóspedes que a suíte pode acomodar.

    - ``ValorDiaria``(decimal): Valor da diária para a suíte.

  - **Construtor**: ``Suite(string tipoSuite, int capacidade, decimal valorDiaria``) - Inicializa as características da suíte.

### 3.3. ``Reserva`` 🗓️
Gerencia as informações de uma reserva específica, relacionando hóspedes e suíte.

  - Propriedades:

    - Hospedes (List<Pessoa>): Uma lista de objetos Pessoa associados à reserva.

    - Suite (Suite): O objeto Suite reservado.

    - DiasReservados (int): A duração da reserva em dias.

    -** Construtor**: ``Reserva(int diasReservados)`` - Inicializa a reserva com a duração e uma lista vazia de hóspedes.

  - **Métodos**:

    - ``CadastrarHospedes(List<Pessoa> hospedes)``:

      - Função: Atribui uma lista de ``Pessoas`` à reserva.

      - Validação: Verifica se o número de hóspedes na lista não excede a ``Capacidade`` da ``Suite`` cadastrada. Se exceder, lança uma ``InvalidOperationException``⚠️.

  - ``CadastrarSuite(Suite suite)``:

      - Função: Associa um objeto ``Suite`` à reserva.

  - ``ObterQuantidadeHospedes()``:

    - Função: Retorna o número atual de hóspedes cadastrados na reserva.

  - ``CalcularValorDiaria()``:

    - Função: Calcula o valor total da reserva.

    - Lógica de Desconto: Aplica um desconto de 10% sobre o valor total se o ``DiasReservados`` for estritamente maior que 10.

    - Retorno: decimal - O valor final da reserva.

## 4. Funcionamento (``Program.cs``) ▶️
O arquivo ``Program.cs`` contém a lógica principal para demonstrar o uso das classes de modelo, criando cenários de teste para reservas válidas e inválidas.

- **Cenário 1**: Reserva Válida com Desconto ✔️

    - Cria uma lista de hóspedes e uma suíte.

    - Define uma duração de dias maior que 10.

    - Cria uma ``Reserva``, cadastra a suíte e os hóspedes.

    - Calcula e exibe o valor total com o desconto aplicado.

- **Cenário 2**: Reserva Válida sem Desconto ✔️

    - Cria uma lista de hóspedes e uma suíte.

    - Define uma duração de dias igual ou menor que 10.

    - Cria uma ``Reserva``, cadastra a suíte e os hóspedes.

    - Calcula e exibe o valor total sem desconto.

- **Cenário 3**: Reserva Inválida (``Hóspedes`` > ``Capacidade da Suíte``) ❌

    - Cria uma lista de hóspedes que excede a capacidade de uma suíte.

    - Tenta cadastrar esses hóspedes na ``Reserva``.

    - Demonstra o tratamento da ``InvalidOperationException`` lançada pelo método ``CadastrarHospedes``.

## 5. Como Executar 🚀
- Clone o repositório ou crie os arquivos conforme a estrutura fornecida.

- Navegue até o diretório raiz do projeto no terminal.

- Execute o comando ``dotnet run``.

## 6. Contribuições e Próximos Passos ✨
Este projeto é um ponto de partida. Sinta-se à vontade para explorá-lo, modificá-lo e, futuramente, expandi-lo para incluir:

- **Gerenciamento de quartos** 🔑 (cadastro, disponibilidade, etc.).

- **Funcionalidades de check-in/check-out**.

- **Interface de usuário** (CLI mais interativa, Web ou Desktop).

- **Persistência de dados** (banco de dados, arquivos).

- **Testes unitários**.
