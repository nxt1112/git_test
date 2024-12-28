using YangiHayotAPI.Data;
using YangiHayotAPI.Enums;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public class ProductService : IProductService   
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext dataContext) 
        {
            _dataContext = dataContext;
            
        }
        public Product? GetByName(string name)
        {
            var product  = _dataContext.Products.FirstOrDefault(p => p.Name == name);
            return product;
        }

        public Product? GetById(int id)
        {
            var product = _dataContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public int Create(string Name, decimal Price, ProductSizeEnum Size, string Photo, double Quantity)
        {
            Product product = new Product();    
            product.Name = Name;    
            product.Price = Price;
            product.Size = Convert.ToString(Size);
            product.Photo = Photo;  
            product.Quantity = Quantity;
            _dataContext.Products.Add(product); 
            _dataContext.SaveChanges();
            return product.Id;
        }

        public List<Product> Index()
        {
            return _dataContext.Products.ToList();  
        }
        
        public Product? Show (int Id)
        {
            var product = _dataContext.Products.FirstOrDefault(p => p.Id == Id);
            return product;     
        }

        public Product? Update(int Id, string Name, decimal Price, string Size, string Photo, double Quantity)
        {
            var product= _dataContext.Products.FirstOrDefault(p => p.Id == Id);
            if (product == null) 
            {
                return null;
            }
            product.Name = Name;    
            product.Price = Price;  
            product.Size = Size;    
            product.Photo = Photo;  
            product.Quantity = Quantity;    
            _dataContext.SaveChanges();
            return product;
        }

        public void Delete(int Id) 
        {
            var product = _dataContext.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null) 
            {
                _dataContext.Products.Remove(product);
                _dataContext.SaveChanges(); 
            }
        }
        
    }
}
