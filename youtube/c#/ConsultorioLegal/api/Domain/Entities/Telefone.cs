namespace src.api.Domain.Entities
{
    public class Telefone
    {
        public Cliente Cliente { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }
    }
}