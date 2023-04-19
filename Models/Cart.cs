namespace asm1_c_sharp.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
