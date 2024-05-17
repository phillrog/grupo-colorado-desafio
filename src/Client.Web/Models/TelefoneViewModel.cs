namespace Client.Web.Models
{
    public class TelefoneViewModel
    {
        public Guid Id { get; set; }
        public int IdCliente { get; set; }
        public string NumeroTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }
        public int IdTipoTelefone { get; set; }
        public string TipoTelefone { get; set; }        
    }
}
