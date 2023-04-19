namespace asm1_c_sharp.Models
{
    public class CartDetails
    {
        public Guid Idcart { get; set; }
        public Guid IdSP { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
        
    }
}
