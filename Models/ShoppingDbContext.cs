using Microsoft.EntityFrameworkCore;
using asm1_c_sharp.Models;
using System.Reflection;
namespace asm1_c_sharp.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext()
        {

        }
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {

        }
        //Thông qua DbSet để get và set dữ liệu qua sql sever
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<User> Users { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-MRQT4GH;Initial Catalog=vinh2003;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=vinh2003;Integrated Security=True");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
