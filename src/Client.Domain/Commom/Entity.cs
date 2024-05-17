namespace Client.Domain.Commom
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public int UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
