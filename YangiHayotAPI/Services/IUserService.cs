using YangiHayotAPI.Models;
using YangiHayotAPI.DTOs;

namespace YangiHayotAPI.Services
{
    public interface IUserService
    {
        public int Create(UserCreateRequest request);

        public List<User> Index();

        public User? GetById(int id);

        public string Update(UserUpdateRequest update);

        public void Delete(int id);
    }
}
