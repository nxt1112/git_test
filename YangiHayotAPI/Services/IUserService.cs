using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public interface IUserService
    {
        public int Create(string FirstName, string LastName, string PhoneNumber, string Email, string Password, int RoleId );

        public List<User> Index();

        public User? GetById(int id);

        public string Update(int id, string FirstName, string LastName, string PhoneNumber, string Email, string Password,int RoleId);

        public void Delete(int id);
    }
}
