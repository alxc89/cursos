using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;
using ConsultorioLegal.api.UI.ModelViews.Especialidade;
using FluentValidation;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository repository;

        public ReferenciaEspecialidadeValidator(IEspecialidadeRepository repository)
        {
            this.repository = repository;
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0)
                .MustAsync(async (id, _) =>
                {
                    return await ExisteNaBase(id);
                }).WithMessage("Especialidade não cadastrada");
        }

        private async Task<bool> ExisteNaBase(int id)
        {
            return await repository.ExisteAsync(id);
        }
    }
}
