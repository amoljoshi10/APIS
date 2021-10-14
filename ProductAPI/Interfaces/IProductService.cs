using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productID);
        void AddProduct(Product product);
        void UpdateProduct(Product product, Product productToUpdate);
        void DeletProduct(Product product);

    }
}
