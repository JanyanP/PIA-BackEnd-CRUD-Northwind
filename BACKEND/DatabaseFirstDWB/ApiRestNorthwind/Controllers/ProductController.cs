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
        // Obtiene una lista de todos los produtos
        [HttpGet]
        public List<ProductModel> Get()
        {
            var products = new ProductSC().GetAllProducts().Select(s => new ProductModel
            {
                // pasa algunos datos de la clase products a un productModel para no mostrar los nombres de los atributos
                idNumber = s.ProductId,
                Name = s.ProductName,
                Price = (decimal)s.UnitPrice,
                Stock = (short)s.UnitsInStock
            }).ToList();
            return products;
        }

        // GET api/<ProductController>/5
        // Obtiene una instancia de Product por id
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var product = new ProductSC().GetProductById(id);
            var productModel = new ProductModel();
            try // Como el metodo GetProductById devuelve un null si no lo encuentra se puso en un try catch
            {   // ya que el ProductModel no acepta datos nulos
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
        // Incerta una instancia de la tabla Product
        [HttpPost]
        public void Post([FromBody] ProductModel newProduct)
        {
            new ProductSC().AddProduct(newProduct);
        }

        // PUT api/<ProductController>/5
        // Actualiza una instancia de la tabla Product
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel product)
        {
            new ProductSC().UpdateProduct(id, product);
        }

        // DELETE api/<ProductController>/5
        // Busca y elimina una instancia de la tabla product
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductSC().RemoveProduct(id);
        }
    }
}
