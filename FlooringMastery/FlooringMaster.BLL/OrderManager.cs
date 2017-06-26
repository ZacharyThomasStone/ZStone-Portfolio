using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(int orderNumber,string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(orderNumber,orderDate);

            if(response.Order == null || response.OrderNumber == 0)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not a valid order date!";
                return response;
            }
         
            else if (response.Order.OrderDate == orderDate && response.Order.OrderNumber == orderNumber)
            {
                response.Success = true;
                return response;
            }
          
                response.Success = false;
                response.Message = $"{orderDate} is not a valid order date!";
                return response;
           
        }

        public OrderAddResponse AddOrder(Order order)
        {
            OrderAddResponse response = new OrderAddResponse();

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = "that is not a valid order!";
                return response;
            }
             _orderRepository.SaveOrder(order);
            response.Success = true;
            return response;
        }

        public OrderRemoveResponse RemoveOrder(Order order, int orderNumber, string orderDate)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();

            response.Order = _orderRepository.LoadOrder(orderNumber, orderDate);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = "That is not a valid order!";
                return response;
            }


        }
    }
}
