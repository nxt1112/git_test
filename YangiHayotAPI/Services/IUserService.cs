using YangiHayotAPI.Models;
using YangiHayotAPI.DTOs;

namespace YangiHayotAPI.Services
{
    public interface IUserService
    {
        public int Create(UserCreateRequest request);

        public List<User> Index();

        public User? GetById(int id);

        public string Update(int id, string FirstName, string LastName, string PhoneNumber, string Email, string Password, int RoleId);

        public void Delete(int id);
        
    }
}
