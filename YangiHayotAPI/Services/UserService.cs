using Microsoft.AspNetCore.Identity;
using YangiHayotAPI.Data;
using YangiHayotAPI.DTOs;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Create (UserCreateRequest request)
        {
            PasswordHelper.HashPassword(request.Password, out byte[] passwordSalt, out byte[] passwordHash);

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = request.RoleId,

            };
            
            _dataContext.Users.Add(user);   
            _dataContext.SaveChanges();
            return user.Id;
        }

        public List<User> Index() 
        {
            return _dataContext.Users.ToList(); 
        }

        public User? GetById(int Id) 
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == Id);
            return (user);
        } 

        public string Update(UserUpdateRequest update)
        {
            PasswordHelper.HashPassword(update.Password, out byte[] passwordSalt, out byte[] passwordHash);

            var user = _dataContext.Users.FirstOrDefault(u => u.Id == update.Id);
            if (user == null)
            {
                return "Not Found";
            }
            update.FirstName = user.FirstName;  
            update.LastName = user.LastName;
            update.PhoneNumber = user.PhoneNumber;
            update.Email = user.Email;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            update.RoleId = user.RoleId;

            _dataContext.SaveChanges();
            return "Updated!";
        }

        public void Delete(int Id)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == Id);
            if (user is not null)
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
            }
        }
    }
}
