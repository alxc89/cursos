namespace ConsultorioLegal.api.Application.Services.Interfaces.Repositories
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteAsync(int id);
    }
}
