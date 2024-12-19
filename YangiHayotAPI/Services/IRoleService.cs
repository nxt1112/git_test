using YangiHayotAPI.Models;
using YangiHayotAPI.Data;

namespace YangiHayotAPI.Services
{
    public interface IRoleService
    {
        public Role? GetByName(string r_name);

        public int Create(string r_name);

        public List<Role> Index();

        public Role? GetById(int id);

        public Role? Update(int id, string r_name);

        public string Delete(int id);   
    }
}
