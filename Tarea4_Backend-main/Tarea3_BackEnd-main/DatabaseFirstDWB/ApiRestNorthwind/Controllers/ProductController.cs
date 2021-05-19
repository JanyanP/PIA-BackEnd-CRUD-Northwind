using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstDWB.BackEnd;
using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductModel> Get()
        {
            var products = new ProductSC().GetAllProducts().Select(s => new ProductModel
            {
                idNumber = s.ProductId,
                Name = s.ProductName,
                Price = (decimal)s.UnitPrice,
                Stock = (short)s.UnitsInStock
            }).ToList();
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var product = new ProductSC().GetProductById(id);
            var productModel = new ProductModel();
            try
            {
                productModel.idNumber = product.ProductId;
                productModel.Name = product.ProductName;
                productModel.Price = (decimal)product.UnitPrice;
                productModel.Stock = (short)product.UnitsInStock;
            }
            catch
            {
                productModel.idNumber = null;
                productModel.Name = "";
                productModel.Price = null;
                productModel.Stock = null;
            }

            return productModel;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel newProduct)
        {
            new ProductSC().AddProduct(newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel product)
        {
            new ProductSC().UpdateProduct(id, product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductSC().RemoveProduct(id);
        }
    }
}
