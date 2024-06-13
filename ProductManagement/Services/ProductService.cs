using Newtonsoft.Json;
using ProductManagement.Interface;
using ProductManagement.Models;

namespace ProductsManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductService()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                _products = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();
            }
            else
            {
                _products = new List<Product>
                {
                    new Product { Id = 1, Name = "Product 1", Price = 10.0m, Quantity = 100 },
                    new Product { Id = 2, Name = "Product 2", Price = 20.0m, Quantity = 200 },
                    new Product { Id = 3, Name = "Product 3", Price = 30.0m, Quantity = 300 }
                };
                SaveToFile();
            }
        }

        public List<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            SaveToFile();
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var jsonData = JsonConvert.SerializeObject(_products);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
