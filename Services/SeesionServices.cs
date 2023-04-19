using asm1_c_sharp.Models;
using Newtonsoft.Json;


namespace ShoppingWebb.Services
{
    public class SessionService
    {
        // Lấy dữ liệu từ session trả về 1 list sản phẩm
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            //B1: lấy string data từ session ở dạng json
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<Product>(); // nếu dữ liệu null thì tạo mới 1 list rỗng
            //B2: convert về list
            var product = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            return product;
        }
        // Ghi dữ liệu từ 1 list vào session
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }

        public static bool CheckExistProduct(Guid id, List<Product> products)
        {
            return products.Any(x => x.ID == id);
        }
        // Kiểm tra sự tồn tại của sản phẩm trong list
    }
}
