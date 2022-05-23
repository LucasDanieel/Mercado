namespace Mercado.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }

        public Endereco Endereco { get; set; }
    }
}