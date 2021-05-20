using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class ProductSC : BaseSC
    {
        public IQueryable<Product> GetAllProducts ()
        {
            return dbContext.Products.Select(s => s);
        }
        public ICollection<OrderDetail> GetOrdersDetail()
        {
            return dbContext.OrderDetails.Select(s => s).ToList();
        }
        public ICollection<OrderDetail> GetOrderDetailsByID(int id)
        {
            return GetOrdersDetail().Where(or => or.ProductId == id).ToList();
        }
        public Product GetProductById(int id)
        {
            return GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();
        }
        
        public void RemoveProduct (int id)
        {
            var orderdetailist = GetOrderDetailsByID(id);
            foreach(OrderDetail od in orderdetailist)
            {
                dbContext.OrderDetails.Remove(od);
            }
            dbContext.SaveChanges();
            var removedProduct = GetProductById(id);
            dbContext.Products.Remove(removedProduct);
            dbContext.SaveChanges();
        }
        public void UpdateProduct (int id, ProductModel product)
        {
            Product currentProduct = GetProductById(id);
            if (currentProduct == null)
            {
                throw new Exception("No se encontró el producto con el ID proporcionado");
            }

            currentProduct.ProductName = product.Name;
            currentProduct.UnitPrice = product.Price;
            currentProduct.UnitsInStock = product.Stock;

            dbContext.SaveChanges();
        }


        public void AddProduct(ProductModel newProduct)
        {
            var newProductRegister = new Product()
            {
                ProductName = newProduct.Name,
                UnitPrice = newProduct.Price,
                UnitsInStock = newProduct.Stock
            };

            dbContext.Products.Add(newProductRegister);
            dbContext.SaveChanges();

        }
    }
}
