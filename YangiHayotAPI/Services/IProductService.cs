using YangiHayotAPI.Enums;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public interface IProductService
    {
        public int Create(string Name, decimal Price, ProductSizeEnum Size, string Photo, double Quantity);

        public Product? GetByName(string Name);

        public List<Product> Index();
        
        public Product? GetById(int Id);
        
        public Product? Update (int Id, string Name, decimal Price, string Size,string Photo, double Quantity);
        
        public void Delete(int Id);
 
    }
}
