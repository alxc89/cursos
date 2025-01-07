using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;
using ConsultorioLegal.api.UI.ModelViews.Medico;
using FluentValidation;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);
            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repository));
        }
    }
}
