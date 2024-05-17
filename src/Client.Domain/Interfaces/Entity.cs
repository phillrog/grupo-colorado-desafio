namespace Client.Domain.Interfaces
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public int UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
