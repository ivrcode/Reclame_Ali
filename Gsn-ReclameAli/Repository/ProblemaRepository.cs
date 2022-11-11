using Gsn_ReclameAli.Common;
using Gsn_ReclameAli.DataContext;
using Gsn_ReclameAli.Interfaces;
using Gsn_ReclameAli.Models;
using Microsoft.EntityFrameworkCore;

namespace Gsn_ReclameAli.Repository
{
    public class ProblemaRepository : IProblemaRepository
    {
        protected readonly GsnReclameAliContext _context;


        public ProblemaRepository(GsnReclameAliContext context)
        {
            _context = context;
        }


        public async Task SalvarProblemaAsync(ProblemaModel problema)
        {
            await _context.AddAsync(problema);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ProblemaModel>> ListarProblemaAsync() => await _context.Problema.ToListAsync();

        public async Task<ProblemaModel> ObterProblemaAsync(int problemaId) => await _context.Problema.FirstAsync(x => x.ProblemaId.Equals(problemaId));

        public void AtualizarProblemaAsync(ProblemaModel problema)
        {
            _context.Update(problema);
            _context.SaveChanges();
        }

        public void DeletarProblemaAsync(ProblemaModel problema)
        {
            _context.RemoveRange(problema);
            _context.SaveChanges();
            
        }
    }
}
