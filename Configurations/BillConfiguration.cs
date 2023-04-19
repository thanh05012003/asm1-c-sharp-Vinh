using asm1_c_sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asm1_c_sharp.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Status).HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.CreateDate).HasColumnType("Datetime");
            // Khóa ngoại tính tiếp
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserID);

        }
    }
}
