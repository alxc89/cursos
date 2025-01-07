namespace ConsultorioLegal.api.Domain.Entities
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}