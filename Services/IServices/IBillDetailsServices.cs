using asm1_c_sharp.Models;
namespace asm1_c_sharp.Services.IServices
{
    public interface IBillDetailsServices
    {
        public List<BillDetail> GetAllBillDetails();
        public List<BillDetail> GetAllBillDetailsId();
        public bool CreateBillDetails(BillDetail billdt);
        public bool UpdateBillDetails(BillDetail billdt);
        public bool DeleteBillDetails(Guid id);
    }
}
