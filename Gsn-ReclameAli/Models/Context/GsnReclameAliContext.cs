using Gsn_ReclameAli.Mappings;
using Gsn_ReclameAli.Models;
using Microsoft.EntityFrameworkCore;

namespace Gsn_ReclameAli.DataContext
{
    public class GsnReclameAliContext: DbContext
    {
        public GsnReclameAliContext(DbContextOptions<GsnReclameAliContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ProblemaModel> Problema { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProblemaMap());


        }
    }
}
