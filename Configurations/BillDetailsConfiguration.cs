using asm1_c_sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asm1_c_sharp.Configurations
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(p => new{p.BillID,p.ProductID});
            // Set thuộc tính
            builder.Property(p => p.Price).IsRequired().    HasColumnType("int");
            builder.Property(p => p.Quantity).IsRequired().HasColumnType("int");
            // Set khóa ngoại - liên kết
            builder.HasOne(p => p.Bill).WithMany().
                HasForeignKey(p => p.BillID);
            builder.HasOne(p => p.Product).WithMany().
                HasForeignKey(p => p.ProductID);
        }
    }
}
