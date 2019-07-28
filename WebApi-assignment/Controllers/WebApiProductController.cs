using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi_assignment.Model;

namespace WebApi_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiProductController : ControllerBase
    {
        private readonly ApidbContext _context;
        public WebApiProductController(ApidbContext context)
        {
            _context = context;
            Seed(_context);
           
        }


        public void Seed(ApidbContext _context) {


            if (_context.ProductItems.Count() == 0)
            {
                _context.ProductItems.Add(new Model.Product { Id = 1, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 2, Name = "Orange Juice", Description = "Juice made of fresh Oranges" });
                _context.ProductItems.Add(new Model.Product { Id = 3, Name = "Grape Juice", Description = "Juice made of fresh Grape" });
                _context.ProductItems.Add(new Model.Product { Id = 4, Name = "Banana Juice", Description = "Juice made of fresh Banana" });
                _context.ProductItems.Add(new Model.Product { Id = 5, Name = "Lemom Juice", Description = "Juice made of fresh Lemom" });
                _context.ProductItems.Add(new Model.Product { Id = 6, Name = "Pineapple Juice", Description = "Juice made of fresh Pineapple" });
                _context.ProductItems.Add(new Model.Product { Id = 7, Name = "Tea", Description = "Hot Masala Tea" });
                _context.ProductItems.Add(new Model.Product { Id = 8, Name = "Coffee", Description = "Hot coffee with original coffee beans" });
                _context.ProductItems.Add(new Model.Product { Id = 9, Name = "Cold Coffee", Description = "Icy cold coffee" });
                _context.ProductItems.Add(new Model.Product { Id = 10, Name = "Coffee latte", Description = "Hot coffee Latte" });
                _context.ProductItems.Add(new Model.Product { Id = 11, Name = "Ice cream", Description = "Chocolate Ice cream" });
                _context.ProductItems.Add(new Model.Product { Id = 12, Name = "Chips", Description = "Cream and Onion Chips" });
                _context.ProductItems.Add(new Model.Product { Id = 13, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 14, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 15, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 16, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 17, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 18, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.ProductItems.Add(new Model.Product { Id = 19, Name = "Apple Juice", Description = "Juice made of fresh apple" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("getproduct")]
        public List<Product> GET()
        {
            var product = _context.ProductItems.ToList();
            return product;
        }

        [HttpPost]
        [Route("insertproduct")]
        public void InsertProductItem(Product item)
        {
            _context.ProductItems.Add(item);
             _context.SaveChangesAsync();
        }

        [HttpDelete]
        [Route("deleteproductbyId/{id:int}")]
        public bool DeleteProductById(int id)
        {
            var product =  _context.ProductItems.Find(id);
            if (product == null)
            {
                return false;
            }
            _context.ProductItems.Remove(product);
            _context.SaveChangesAsync();

            return true;
        }

        [HttpPut]
        [Route("updateproduct/{id:int}")]
        public bool UpdateProduct(int id, [FromBody]Product request)
        {
            var product =  _context.ProductItems.Find(id);
            if (product == null) {
                return false;
            }
            else
            {
                product.Name = request.Name;
                product.Description = request.Description;
                _context.ProductItems.Attach(product);
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChangesAsync();
                return true;
            }
            
        }

        [HttpGet]
        [Route("getproduct/{id:int}")]
        public Product GetProductbyId(int id)
        {
            var product =  _context.ProductItems.Find(id);

            return product;
        }

        [HttpGet]
        [Route("getpagelist/{page:int}/{pagesize:int}")]
        public string GetPageList(int page, int pagesize)
        {
            var allProductList = _context.ProductItems.ToList();

            // Get's No of Rows Count   
            int totalProduct = allProductList.Count;

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = page;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pagesize;

            // Display TotalCount to Records to User 

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(totalProduct / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var items = allProductList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            var data = new { Total_Product = totalProduct, Product_Items = items };

            string json1 = JsonConvert.SerializeObject(data);
            return json1;
    }

    }
}