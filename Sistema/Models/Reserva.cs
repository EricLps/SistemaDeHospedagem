using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        // Construtor principal que inicializa a lista de hóspedes
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        // Método para cadastrar a lista de hóspedes
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // valida se a quantidade de hóspedes não excede a capacidade da suíte
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // lança uma exceção se a capacidade for excedida
                throw new InvalidOperationException(
                    $"Erro: O número de hóspedes ({hospedes.Count}) excede a capacidade da suíte ({Suite.Capacidade})."
                );
            }
        }

        // Método para cadastrar a suíte na reserva
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% se a reserva for maior que 10 dias
            if (DiasReservados > 10)
            {
                Console.WriteLine("Aplicando desconto de 10% por reserva de mais de 10 dias...");
                valorTotal *= 0.90M;
            }

            return valorTotal;
        }
    }
}