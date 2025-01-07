using src.api.Domain.Entities;

namespace ConsultorioLegal.api.UI.ModelViews.Endereco
{
    public class NovoEndereco
    {
        ///<example>49000000</example>
        public string CEP { get; set; }
        ///<example>SP</example>
        public string Estado { get; set; }
        ///<example>São José do Rio Preto</example>
        public string Cidade { get; set; }
        ///<example>Rua A</example>
        public string Logradouro { get; set; }
        ///<example>15</example>
        public string Numero { get; set; }
        ///<example>Ao lado do posto</example>
        public string Complemento { get; set; }
    }
}