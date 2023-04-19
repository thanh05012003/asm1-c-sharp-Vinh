using System;
using System.Linq;
using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;


namespace asm1_c_sharp.Services
{
    public class RoleServices : IRoleServices
    {
        ShoppingDbContext _shopDbContext;
        public RoleServices()
        {
            _shopDbContext = new ShoppingDbContext();
        }

        public bool CreateRoles(Role Roles)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoles(Role id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetRole()
        {
            throw new NotImplementedException();
        }

        public Cart GetRolesById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoles(Role Roles)
        {
            throw new NotImplementedException();
        }
    }
}
