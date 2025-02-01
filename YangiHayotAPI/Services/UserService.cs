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

        public User? GetById(int id) 
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == id);
            return (user);
        } 

        public string Update(int id, string FirstName, string LastName, string PhoneNumber, string Email, string Password, int RoleId)
        {
            
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return "Not Found";
            }
            user.Id = id;   
            user.FirstName = FirstName; 
            user.LastName = LastName;
            user.PhoneNumber = PhoneNumber;
            user.Email = Email;
            //user.Password = Password;
            user.RoleId = RoleId;
            

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
