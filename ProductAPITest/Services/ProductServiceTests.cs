using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Services.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        public void GetProductByIdTest()
        {
            var productService = new ProductService();
            var response = productService.GetProductById(1);
            
            if (response != null)
                Assert.AreEqual(response.ProductID, 1);
            else
                Assert.Fail();
        }

        [TestMethod()]
        public void GetProductsTest()
        {
            var productService = new ProductService();
            List<Product> response = productService.GetProducts().ToList() ?? null;
            if (response != null)
                Assert.AreEqual(response.Count, 20);
            else
                Assert.Fail();
        }
    }
}