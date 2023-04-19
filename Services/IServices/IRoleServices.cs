using asm1_c_sharp.Models;

namespace asm1_c_sharp.Services.IServices
{
    public interface IRoleServices
    {
        public List<Cart> GetRole();

        public Cart GetRolesById(Guid id);


        public bool CreateRoles(Role Roles);
        public bool UpdateRoles(Role Roles);
        public bool DeleteRoles(Role id);

    }
}
