using asm1_c_sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asm1_c_sharp.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ID);
            builder.Property(p => p.Supplier).IsUnicode(true).
                IsFixedLength().HasMaxLength(1000);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            // 2 đoạn config trên là như nhau
        }
    }
}
