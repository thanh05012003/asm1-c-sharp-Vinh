
using asm1_c_sharp.Models;

namespace asm1_c_sharp.Services.IServices
{
    public interface IProductServices
    {
        public List<Product> GetAllProduct();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
        public bool CreateProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(Guid id);

    }
}
