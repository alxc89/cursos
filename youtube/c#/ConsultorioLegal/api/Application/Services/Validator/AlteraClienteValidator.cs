using ConsultorioLegal.api.UI.ModelViews.Cliente;
using FluentValidation;
using src.api.Application.Services.Validator;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}
