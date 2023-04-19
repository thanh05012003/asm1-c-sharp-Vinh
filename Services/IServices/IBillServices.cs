using asm1_c_sharp.Models;

namespace asm1_c_sharp.Services.IServices
{
    public interface IBillServices
    {
        public List<Bill> GetAllBill();
        public Bill GetBillById(Guid id);
        
        public bool CreateBill(Bill bill);
        public bool UpdateBill(Bill bill);
        public bool DeleteBill(Guid id);
    }
}
