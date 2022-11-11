using Gsn_ReclameAli.Common;
using Gsn_ReclameAli.Models;

namespace Gsn_ReclameAli.Interfaces
{
    public interface IProblemaService
    {
        Task SalvarProblemaAsync(ProblemaModel problema);

        Task<Resultado<List<ProblemaModel>>> ListarProblemaAsync();

        Task<Resultado<ProblemaModel>> ObterProblemaAsync(int problemaId);

        Task<Resultado<ProblemaModel>> AtualizarProblemaAsync(ProblemaModel problema);

        Task<Resultado<ProblemaModel>> DeletarProblemaAsync(int problemaid);
    }
}
