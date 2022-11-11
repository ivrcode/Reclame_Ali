using Gsn_ReclameAli.Common;
using Gsn_ReclameAli.Models;

namespace Gsn_ReclameAli.Interfaces
{
    public interface IProblemaRepository
    {

        Task SalvarProblemaAsync(ProblemaModel problema);

        Task <List<ProblemaModel>> ListarProblemaAsync();

        Task<ProblemaModel> ObterProblemaAsync(int problemaId);

        void AtualizarProblemaAsync(ProblemaModel problema);

        void  DeletarProblemaAsync(ProblemaModel problema);


    }
}
