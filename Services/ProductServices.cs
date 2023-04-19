

using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;

namespace asm1_c_sharp.Services
{
    public class ProductService : IProductServices
    {
        ShoppingDbContext _shopDbContext;

        public ProductService()
        {
            _shopDbContext = new ShoppingDbContext();
        }
        public List<Product> GetAllProduct()
        {
            return _shopDbContext.Products.ToList(); // Lấy tất cả các sản phẩm
        }

        public Product GetProductById(Guid id)
        {
            var pr = _shopDbContext.Products.FirstOrDefault(p => p.ID == id);
            return pr;
        }

        public List<Product> GetProductByName(string name)
        {
            return _shopDbContext.Products.Where(p => p.Name.Contains(name)).ToList();
            //Trả về danh sách những Sản Phẩm mà tên có chứa chuỗi cần tìm
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                product.ID = Guid.NewGuid();
                _shopDbContext.Products.Add(product);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                var p = _shopDbContext.Products.FirstOrDefault(p => p.ID == product.ID);
                p.Name = product.Name;
                p.Description = product.Description;
                p.Price = product.Price;
                p.AvailableQuantity = product.AvailableQuantity;
                p.Category = product.Category;
                p.Brand = product.Brand;
                p.ImageUrl = product.ImageUrl;
                p.Status = product.Status;
                _shopDbContext.Products.Update(p);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = _shopDbContext.Products.FirstOrDefault(p => p.ID == id);
                _shopDbContext.Products.Remove(product);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
