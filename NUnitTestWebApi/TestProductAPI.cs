using ApplicationWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi_assignment;
using WebApi_assignment.Controllers;
using WebApi_assignment.Model;
using Assert = NUnit.Framework.Assert;

namespace NUnitTestWebApi
{
    [TestClass]
    public class TestProductAPI
    {

        private readonly ApidbContext dbContext;
        [Test]
        public void TestGetProductCount() {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var Testresult = context.ProductItems;
            var getData = service.GET();
            Assert.AreEqual(Testresult, getData);


        }
        [Test]
        public void TestGetProductbyId() {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var Testresult = context.ProductItems.FindAsync(6);
            var getData = service.GetProductbyId(6);
            Assert.AreEqual(Testresult.Result.Name, getData.Name);
        }

        [Test]
        public void TestDeleteProductById()
        {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var isDeleted = service.DeleteProductById(5);
            Product getData = service.GetProductbyId(5);
            Assert.IsNull(getData);
        }

        [Test]
        public void TestProductNotFoundById()
        {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var Testresult = context.ProductItems.FindAsync(100);
            Assert.IsNull(Testresult.Result);
        }

        [Test]
        public void TestUpdateProductById()
        {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            Product prod = new Product();
            prod.Id = 2;
            prod.Name = "UpdatedProduct";
            prod.Description = "Description";
            service.UpdateProduct(2,prod);
            var getUpdatedProduct = service.GetProductbyId(2);
            Assert.AreEqual(getUpdatedProduct.Name, "UpdatedProduct");
        }

        [Test]
        public void TestTotalProductPerPages()
        {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var pageData = service.GetPageList(2, 5);
            var model = JsonConvert.DeserializeObject<ProductPage>(pageData);
            var productItems = model.Product_Items;
            Assert.AreEqual(productItems.Count, 5);
        }
        [Test]
        public void TestPageNotFoundOnPage()
        {
            var option = new DbContextOptionsBuilder<ApidbContext>()
                .UseInMemoryDatabase(databaseName: "webAPIdb")
                .Options;

            // Run the test against one instance of the context
            var context = new ApidbContext(option);
            var service = new WebApiProductController(context);
            service.Seed(context);
            var pageData = service.GetPageList(10, 5);
            var model = JsonConvert.DeserializeObject<ProductPage>(pageData);
            var productItems = model.Product_Items;
            Assert.AreEqual(productItems.Count,0);
        }



    }
}
