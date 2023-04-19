namespace asm1_c_sharp.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public float Discount { get; set; }
        public DateTime CreatedDate { get; set; }
       
    }

}
