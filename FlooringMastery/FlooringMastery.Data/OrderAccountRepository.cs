using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class OrderAccountRepository : IOrderRepository
    {
     
       
        public Order LoadOrder(int orderNumber, string orderDate)
        {
            string path = $"C:\\Data\\FlooringMastery\\Orders\\Orders_{orderDate}.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] fields = line.Split(',');
                    if (int.Parse(fields[0]) == orderNumber)
                    {
                        Order tempOrder = new Order();
                        tempOrder.OrderNumber = int.Parse(fields[0]);
                        tempOrder.CustomerName = fields[1];
                        tempOrder.State = fields[2];
                        tempOrder.TaxRate = decimal.Parse(fields[3]);
                        tempOrder.ProductType = fields[4];
                        tempOrder.Area = decimal.Parse(fields[5]);
                        tempOrder.CostPerSquareFoot = decimal.Parse(fields[6]);
                        tempOrder.LaborCostPerSquareFoot = decimal.Parse(fields[7]);
                        tempOrder.MaterialCost = decimal.Parse(fields[8]);
                        tempOrder.LaborCost = decimal.Parse(fields[9]);
                        tempOrder.Tax = decimal.Parse(fields[10]);
                        tempOrder.Total = decimal.Parse(fields[11]);


                        return tempOrder;
                    }
                }
            }
            return null;

        }
        public void SaveOrder(Order order)
        {
            List<Order> orders = new List<Order>();
          
            string path = $"C:\\Data\\FlooringMastery\\Orders\\Orders_{order.OrderDate}.txt";
            //Load file into a list of orders
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {


                    string[] fields = line.Split(',');
                    if (int.Parse(fields[0]) == order.OrderNumber)
                    {
                        Order tempOrder = new Order();
                        tempOrder.OrderNumber = int.Parse(fields[0]);
                        tempOrder.CustomerName = fields[1];
                        tempOrder.State = fields[2];
                        tempOrder.TaxRate = decimal.Parse(fields[3]);
                        tempOrder.ProductType = fields[4];
                        tempOrder.Area = decimal.Parse(fields[5]);
                        tempOrder.CostPerSquareFoot = decimal.Parse(fields[6]);
                        tempOrder.LaborCostPerSquareFoot = decimal.Parse(fields[7]);
                        tempOrder.MaterialCost = decimal.Parse(fields[8]);
                        tempOrder.LaborCost = decimal.Parse(fields[9]);
                        tempOrder.Tax = decimal.Parse(fields[10]);
                        tempOrder.Total = decimal.Parse(fields[11]);


                        orders.Add(tempOrder);


                        foreach (var specificOrder in orders)
                        {
                            if (specificOrder == order)
                            {
                                tempOrder = order;

                            }

                        }

                    }

                }
                reader.Close();
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.Tax},{order.Total}");

                }
                  
                
            }
        }
        public void RemoveOrder()
        {

        }

        public OrderAddResponse Add(Order order)
        {
            throw new NotImplementedException();
        }

        public OrderLookupResponse Lookup(Order order, int orderNumber, string orderDate)
        {
            throw new NotImplementedException();
        }

        public OrderEditResponse Edit(Order order, string orderNumber, string orderDate)
        {
            throw new NotImplementedException();
        }

        public OrderRemoveResponse Remove(Order order, int orderNumber, string orderDate)
        {
            throw new NotImplementedException();
        }
    } 
}
