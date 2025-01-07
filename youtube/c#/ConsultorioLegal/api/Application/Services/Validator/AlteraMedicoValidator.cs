using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;
using ConsultorioLegal.api.UI.ModelViews.Medico;
using FluentValidation;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
    {
        public AlteraMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoMedicoValidator(repository));
        }
    }
}
