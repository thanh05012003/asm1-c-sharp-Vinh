using asm1_c_sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace asm1_c_sharp.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Username).IsRequired().
                HasColumnType("varchar(256)");
            builder.HasOne(p => p.Role).WithMany().HasForeignKey(c => c.RoleId);
        }
    }
}
