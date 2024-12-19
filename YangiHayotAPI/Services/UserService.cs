using YangiHayotAPI.Data;
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

        public int Create (string FirstName, string LastName, string PhoneNumber, string Email, string Password, int RoleId)
        {
            User user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Password = Password,
                RoleId = RoleId,
                
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

        public string Update(int Id, string FirstName, string LastName, string PhoneNumber, string Email, string Password, int RoleId)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == Id);
            if (user == null)
            {
                return "Not Found";
            }
            user.FirstName = FirstName; 
            user.LastName = LastName;   
            user.PhoneNumber = PhoneNumber; 
            user.Email = Email; 
            user.Password = Password;   
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
