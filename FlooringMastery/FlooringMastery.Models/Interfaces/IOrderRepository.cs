using FlooringMastery.Models.Responses;
using System;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(int OrderNumber,string OrderDate);
        void SaveOrder(Order order);
        OrderAddResponse Add(Order order);
        OrderLookupResponse Lookup(Order order, int orderNumber, string orderDate);
        OrderEditResponse Edit(Order order, string orderNumber, string orderDate);
        OrderRemoveResponse Remove(Order order, int orderNumber, string orderDate);

    }
}
