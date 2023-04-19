using asm1_c_sharp.Models;
using asm1_c_sharp.ViewModel;

namespace asm1_c_sharp.Services.IServices
{
    public interface ICartServices
    {
        public List<Cart> GetCarts();

        public Cart GetCartById(Guid id);


        public bool CreateCart(Cart cart);
        public bool UpdateCart(Cart cart);
        public bool DeleteCart(Guid id);
        public List<CartView> GetCartView();
    }
}
