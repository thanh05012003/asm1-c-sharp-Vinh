namespace asm1_c_sharp.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        
        public Guid UserID { get; set; }

        public int Status { get; set; }

       

        public User User { get; set; }  
    }
}
