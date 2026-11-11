using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DemoAPI.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProductAPI.Interfaces;

namespace DemoAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        private ProductsController productController;
        private List<Product> productsData;
        private Mock<IProductService> mockProductService;

        private Mock<ISecurityHeaderProvider> mockSecurityHeader;

        [TestInitialize]
        public void Initialize()
        {
            var productMock = new Mock<Product>();
            mockProductService = new Mock<IProductService>();
            mockSecurityHeader = new Mock<ISecurityHeaderProvider>();
            mockSecurityHeader.Setup(s => s.GetSecurityHeader()).Returns("test-header");


            productsData = new List<Product>();

            for (int i = 1; i <= 20; i++)
            {
                productsData.Add(new Product { ProductID = i, ProductCategory = "Cateory" + i, ProductDescription = "Product" + i });
            }
          
            
        }

        private ProductsController NewController(string header="test-header")
        {
            var httpContext=new DefaultHttpContext();
            if(header != null) httpContext.Request.Headers["x-security-header"]=header;
            return new ProductsController(mockProductService.Object, mockSecurityHeader.Object)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext }
            };
        }

        

        [TestMethod()]
        public void GetTest()
        {
            mockProductService.Setup(p => p.GetProducts()).Returns(productsData.AsEnumerable());
            productController = NewController();

            var result = productController.Get();
            Assert.AreEqual(20, result.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var product = new Product() {ProductID=1,ProductDescription="Test Product",ProductCategory="TestCatgory"};


            mockProductService.Setup(p => p.GetProductById(1)).Returns(product);
            productController = NewController();

            var result = productController.GetById(1);

            var actionResult = result as ObjectResult;

            // assert
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(actionResult is OkObjectResult);

            var castedProduct = actionResult.Value as Product;
            if(castedProduct!=null)
            {
                Assert.AreEqual(1, castedProduct.ProductID);
            }
            
            Assert.AreEqual(200, actionResult.StatusCode);

        }

       
    }
}
