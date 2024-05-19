namespace Client.Infrastructure.Data.Models
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataInclusao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
