using Editora.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Editora.Repository.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UltimoNome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.DataNascimento).IsRequired();

            builder.HasMany(x => x.Livros).WithOne(x => x.Autor);

        }
    }
}
