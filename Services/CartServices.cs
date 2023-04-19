using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;
using asm1_c_sharp.ViewModel;

namespace asm1_c_sharp.Services
{
    public class CartServices : ICartServices
    {
        ShoppingDbContext _shopDbContext;

        public CartServices()
        {
            _shopDbContext = new ShoppingDbContext();
        }
        public bool CreateCart(Cart cart)
        {
            try
            {
              
                _shopDbContext.Carts.Add(cart);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        

        public bool DeleteCart(Guid id)
        {
            try
            {
                var cart = _shopDbContext.Carts.FirstOrDefault(p => p.UserId == id);
                _shopDbContext.Carts.Remove(cart);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CartView> GetCartView()
        {
            var cartView = from a in _shopDbContext.Carts
                join b in _shopDbContext.CartDetails on a.Id equals b.Idcart
                join c in _shopDbContext.Products on b.IdSP equals c.ID
                select new CartView()
                {
                    IdCart = a.Id,
                    Images = c.ImageUrl,
                    NamePro = c.Name,
                    Price = (int)(c.Price * b.Quantity),
                    Quantity = b.Quantity,
                    UserId = a.UserId,
                    IdProduct = c.ID
                };
            return cartView.ToList();
        }


        public Cart GetCartById(Guid id)
        {
            var cart = _shopDbContext.Carts.FirstOrDefault(p => p.UserId == id);
            return cart;
        }

        public List<Cart> GetCarts()
        {
            return _shopDbContext.Carts.ToList();
        }

        public bool UpdateCart(Cart cart)
        {
            try
            {
                var p = _shopDbContext.Products.FirstOrDefault(p => p.ID == cart.UserId);
                cart.User = cart.User;
                cart.UserId = cart.UserId;
                cart.Description = cart.Description;





                _shopDbContext.Carts.Update(cart);
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
