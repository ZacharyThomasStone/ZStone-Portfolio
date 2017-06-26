using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMaster.BLL.LookupRules
{
    public class OrderLookupRule : ILookup
    {
        public OrderLookupResponse Lookup(Order order, int orderNumber, string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            if(order.OrderNumber != orderNumber)
            {
                response.Success = false;
                response.Message = "There is not an order with that number.";
                return response;
            }
            else if (order.OrderDate != orderDate)
            {
                response.Success = false;
                response.Message = "There is not an order with that date.";
                return response;
            }
            response.Order = order;
            response.OrderNumber = orderNumber;
            response.Success = true;
            return response;
        }
    }
}
