
using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;

namespace asm1_c_sharp.Services
{
    public class UserServices : IUserServices
    {
        ShoppingDbContext _shopDbContext;
        public UserServices()
        {
            _shopDbContext = new ShoppingDbContext();
        }

        public bool CreateUser(User user)
        {
            try
            {
               
                _shopDbContext.Users.Add(user);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var user = _shopDbContext.Users.FirstOrDefault(User => User.Id == id);
                _shopDbContext.Users.Remove(user);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<User> GetAllUser()
        {
            return _shopDbContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            var user = _shopDbContext.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }

       

        public bool UpdateUser(User user)
        {
            try
            {
                var User = _shopDbContext.Users.FirstOrDefault(a => a.Id == user.Id);
                User.Username = user.Username;
                User.Password = user.Password;
          
                User.RoleId = user.RoleId;
           
                _shopDbContext.Users.Update(user);
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
