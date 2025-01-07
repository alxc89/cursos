namespace ConsultorioLegal.api.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
    }
}
