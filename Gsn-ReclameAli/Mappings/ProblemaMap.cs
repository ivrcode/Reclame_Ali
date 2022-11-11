using Gsn_ReclameAli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gsn_ReclameAli.Mappings
{
    public class ProblemaMap : IEntityTypeConfiguration<ProblemaModel>
    {
        public void Configure(EntityTypeBuilder<ProblemaModel> builder)
        {
            builder.HasKey(p => p.ProblemaId);
           

        }
    }
}
