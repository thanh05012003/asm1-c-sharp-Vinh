using asm1_c_sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asm1_c_sharp.Configurations
{
    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(c => new { c.Idcart, c.IdSP });
            builder.Property(c => c.Quantity).HasColumnType("int").IsRequired();
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.IdSP);
            builder.HasOne(c => c.Cart).WithMany().HasForeignKey(c => c.Idcart);

        }
    }
}
