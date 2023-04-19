using asm1_c_sharp.Models;
namespace asm1_c_sharp.Services.IServices
{
    public interface IUserServices
    {
        public List<User> GetAllUser();
        public User GetUserById(Guid id);
        
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(Guid id);
    }
}
