using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Interfaces;

namespace DemoAPI.Services
{
    public class ProductService : IProductService
    {

        public static List<Product> _products;
        public Product GetProductById(int productID)
        {
            return GetProducts().FirstOrDefault(p => p.ProductID == productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            if(_products!=null)
            {
                return _products;
            }
            _products =new List<Product>();

            for (int i = 1; i <= 20; i++)
            {
                _products.Add(new Product { ProductID = i, ProductCategory = "Cateory" + i, ProductDescription = "Product" + i });
            }

            return _products;
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void UpdateProduct(Product product,Product updatedProduct)
        {
            _products.Remove(product);
            _products.Add(updatedProduct);
        }
        public void DeletProduct(Product product)
        {
            _products.Remove(product);
        }

    }
}
