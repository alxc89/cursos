using ConsultorioLegal.api.UI.ModelViews.Especialidade;

namespace ConsultorioLegal.api.UI.ModelViews.Medico
{
    public class NovoMedico
    {
        /// <summary>
        /// Nome do Médico.
        /// </summary>
        /// <example>Dr. João Costa</example>  
        public string Nome { get; set; }

        /// <summary>
        /// CRM do Médico
        /// </summary>
        /// <example>123456</example>
        public int CRM { get; set; }
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
