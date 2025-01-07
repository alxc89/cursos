using ConsultorioLegal.api.UI.ModelViews.Telefone;
using FluentValidation;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(x => x.Numero).Matches("^[0-9]{2}-([0-9]{8}|[0-9]{9})")
                            .WithMessage("O telefone tem que ter o formato [1-9][0-9]{10}");
        }
    }
}
