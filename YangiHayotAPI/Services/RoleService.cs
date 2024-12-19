
using YangiHayotAPI.Data;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _dataContext;
        public RoleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Role? GetByName(string name)
        {
            var role = _dataContext.Roles.FirstOrDefault(r => r.Name == name);
            return role;
        }

        public int Create(string r_name)
        {
            if (GetByName(r_name) != null)
            {
                throw new ArgumentException("This role is already chosen.");
            }

            Role role = new Role()
            {
                Name = r_name,
            };
            _dataContext.Roles.Add(role);
            _dataContext.SaveChanges();

            return role.Id;
        }


        public List<Role> Index() 
        {
            return _dataContext.Roles.ToList(); 
        }

        public Role? GetById(int id) 
        {
            var role = _dataContext.Roles.FirstOrDefault(r => r.Id == id);
            return role;
        }

        public Role? Update(int id, string r_name)
        {
            
            var role = _dataContext.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return null; 
            }

            
            role.Name = r_name;
            _dataContext.SaveChanges(); 
            return role; 
        }

        public string Delete(int id) 
        {
            var role = _dataContext.Roles.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                _dataContext.Roles.Remove(role);
                _dataContext.SaveChanges();
            }
            return "Deleted";
        }
    }
}
