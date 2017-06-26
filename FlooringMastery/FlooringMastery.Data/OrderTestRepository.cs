using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 12345,
            OrderDate = "12/13/19",
            CustomerName = "Zachary Stone",
            State = "Kentucky",
            ProductType = "Wood",
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M,

        };
        public Order LoadOrder(int OrderNumber, string OrderDate)
        {
            return _order;
        }
        public void SaveOrder(Order order)
        {
            _order = order;
        }
    }
}
