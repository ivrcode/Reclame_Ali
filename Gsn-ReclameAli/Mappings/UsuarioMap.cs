using Gsn_ReclameAli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gsn_ReclameAli.Mappings
{
    public class UsuarioMap: IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.UsuarioId);
        }
    }
}
