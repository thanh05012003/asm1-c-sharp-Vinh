
using asm1_c_sharp.Models;

namespace asm1_c_sharp.Services.IServices
{
    public interface ICartDetailServices
    {
        public List<CartDetails> GetCartDetail();

        public CartDetails GetCartDetailById(Guid id);


        public bool CreateCartDetail(CartDetails cartdt);
        public bool UpdateCartDetails(CartDetails cartdt);
        public bool DeleteCartDetails(Guid id);
    }
}
