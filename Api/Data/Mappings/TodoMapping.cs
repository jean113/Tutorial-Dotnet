using Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings;
public class TodoMapping : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todo");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Tarefa).IsRequired().HasColumnType("varchar").HasMaxLength(100);

        builder.Property(x => x.Feito).IsRequired().HasDefaultValue(false);
        
        builder.Property(x => x.DataCriacao).IsRequired().HasDefaultValueSql("GETDATE()");
    }
    
}