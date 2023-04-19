
using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace asm1_c_sharp.Services
{
    public class CartDetailsServices : ICartDetailServices
    {
        ShoppingDbContext _shopDbContext;

        public CartDetailsServices()
        {
            _shopDbContext = new ShoppingDbContext();
        }
        public bool CreateCartDetail(CartDetails cartdt)
        {
            try
            {
               
                _shopDbContext.CartDetails.Add(cartdt);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
                var cartdt = _shopDbContext.CartDetails.FirstOrDefault(p => p.Idcart == id);
                _shopDbContext.CartDetails.Remove(cartdt);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CartDetails> GetCartDetail()
        {
            return _shopDbContext.CartDetails.ToList();
        }

        public CartDetails GetCartDetailById(Guid id)
        {
            var cartdt = _shopDbContext.CartDetails.FirstOrDefault(p => p.Idcart == id);
            return cartdt;
        }

        public bool UpdateCartDetails(CartDetails cartdt)
        {
            try
            {
                var p = _shopDbContext.CartDetails.FirstOrDefault(p => p.Idcart == cartdt.Idcart);
              
                p.Product = cartdt.Product;
                p.Cart = cartdt.Cart;
                p.Quantity = cartdt.Quantity;
                _shopDbContext.CartDetails.Update(p);
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
