using System;
using System.Collections.Generic;
using SistemaHospedagem.Models;

namespace SistemaHospedagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para exibir símbolos de moeda corretamente

            Console.WriteLine("Bem-vindo ao Sistema de Reservas de Hotel!\n");

            //Reserva Válida com Desconto ---
            Console.WriteLine("--- Cenário 1: Reserva Válida com Desconto ---");
            List<Pessoa> hospedes1 = new List<Pessoa>
            {
                new Pessoa("João", "Silva"),
                new Pessoa("Maria", "Souza")
            };

            Suite suitePremium = new Suite("Premium", 3, 150.00M); // Capacidade 3, Diária 150
            int diasReservados1 = 12; // Mais de 10 dias para ativar o desconto

            Reserva reserva1 = new Reserva(diasReservados1);
            reserva1.CadastrarSuite(suitePremium);

            try
            {
                reserva1.CadastrarHospedes(hospedes1);

                Console.WriteLine($"\nReserva 1:");
                Console.WriteLine($"Hóspedes: {string.Join(", ", reserva1.Hospedes.Select(h => h.NomeCompleto))}");
                Console.WriteLine($"Quantidade de Hóspedes: {reserva1.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Suíte: {reserva1.Suite.TipoSuite} (Capacidade: {reserva1.Suite.Capacidade})");
                Console.WriteLine($"Dias Reservados: {reserva1.DiasReservados}");
                Console.WriteLine($"Valor Diária da Suíte: {reserva1.Suite.ValorDiaria:C}"); // :C para formatar como moeda
                Console.WriteLine($"Valor Total da Reserva: {reserva1.CalcularValorDiaria():C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro na Reserva 1: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado na Reserva 1: {ex.Message}");
            }

            Console.WriteLine("\n------------------------------------------------\n");

            //Reserva válida sem desconto
            Console.WriteLine("--- Cenário 2: Reserva Válida sem Desconto ---");
            List<Pessoa> hospedes2 = new List<Pessoa>
            {
                new Pessoa("Ana", "Pereira")
            };

            Suite suiteStandard = new Suite("Standard", 2, 80.00M); // Capacidade 2, diária 80
            int diasReservados2 = 7; // Menos de 10 dias, sem desconto

            Reserva reserva2 = new Reserva(diasReservados2);
            reserva2.CadastrarSuite(suiteStandard);

            try
            {
                reserva2.CadastrarHospedes(hospedes2);

                Console.WriteLine($"\nReserva 2:");
                Console.WriteLine($"Hóspedes: {string.Join(", ", reserva2.Hospedes.Select(h => h.NomeCompleto))}");
                Console.WriteLine($"Quantidade de Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Suíte: {reserva2.Suite.TipoSuite} (Capacidade: {reserva2.Suite.Capacidade})");
                Console.WriteLine($"Dias Reservados: {reserva2.DiasReservados}");
                Console.WriteLine($"Valor Diária da Suíte: {reserva2.Suite.ValorDiaria:C}");
                Console.WriteLine($"Valor Total da Reserva: {reserva2.CalcularValorDiaria():C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro na Reserva 2: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado na Reserva 2: {ex.Message}");
            }

            Console.WriteLine("\n------------------------------------------------\n");

            //Reserva inválida (hóspedes > capacidade)
            Console.WriteLine("--- Cenário 3: Reserva Inválida (Hóspedes > Capacidade) ---");
            List<Pessoa> hospedes3 = new List<Pessoa>
            {
                new Pessoa("Carlos", "Lima"),
                new Pessoa("Julia", "Costa"),
                new Pessoa("Pedro", "Santos")
            };

            Suite suiteSimples = new Suite("Simples", 2, 50.00M); // Capacidade 2, Diária 50
            int diasReservados3 = 5;

            Reserva reserva3 = new Reserva(diasReservados3);
            reserva3.CadastrarSuite(suiteSimples); // cadastra a suíte primeiro

            try
            {
                // Aqui a exceção de capacidade será iniciada
                reserva3.CadastrarHospedes(hospedes3);

                // Essas linhas não serão executadas se a exceção iniciar
                Console.WriteLine($"\nReserva 3:");
                Console.WriteLine($"Quantidade de Hóspedes: {reserva3.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor Total da Reserva: {reserva3.CalcularValorDiaria():C}");
            }
            catch (InvalidOperationException ex) // Pega a exceção específica iniciada
            {
                Console.WriteLine($"\nErro ao tentar cadastrar hóspedes na Reserva 3: {ex.Message}");
            }
            catch (Exception ex) // captura qualquer outra exceção inesperada
            {
                Console.WriteLine($"Ocorreu um erro inesperado na Reserva 3: {ex.Message}");
            }

            Console.WriteLine("\n------------------------------------------------\n");
            Console.WriteLine("Fim do programa.");
        }
    }
}