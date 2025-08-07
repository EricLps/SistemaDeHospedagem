namespace SistemaHospedagem.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        //somente leitura que combina Nome e Sobrenome
        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}