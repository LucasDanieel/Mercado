namespace Mercado.Models
{
    public class Endereco
    { 
        public int UserId { get; set; }
        public string Rua { get; set; }
        public int NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }

        public User User { get; set; }
    }
}