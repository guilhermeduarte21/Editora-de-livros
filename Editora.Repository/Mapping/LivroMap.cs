using Editora.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Editora.Repository.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.ISBN).IsRequired();
            builder.Property(x => x.Titulo).IsRequired();

            builder.Property(x => x.AutorId).IsRequired();

        }
    }
}
