using DatabaseFirstDWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    class OrderSC : BaseSC
    { 
        public IQueryable<Order> GetOrderById(int OrderId)
        {
            return GetAllOrders().Where(o => o.OrderId == OrderId);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return dbContext.Orders;
        }
    }
}
