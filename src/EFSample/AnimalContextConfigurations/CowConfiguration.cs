using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MTech.EFSample.AnimalContextConfigurations
{
    public class CowConfiguration : IEntityTypeConfiguration<Cow>
    {
        public void Configure(EntityTypeBuilder<Cow> builder)
        {
            builder.ToTable("Cow");
        }
    }
}
