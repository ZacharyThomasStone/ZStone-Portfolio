using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System.IO;

namespace FlooringMaster.BLL.LookupRules
{
    public class OrderAddRule : IAdd
    {
        public OrderAddResponse Add(Order order, string orderNumber, string orderDate, string customerName, string state, decimal taxRate, string productType, decimal materialType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal laborCost, decimal tax, decimal total)
        {
            OrderAddResponse response = new OrderAddResponse();
            using (StreamReader reader = new StreamReader(@"C:\Data\FlooringMastery\Taxes.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields[0] != state.ToUpper() || fields[2] != state)
                    {
                        response.Success = false;
                        response.Message = "That state is not one we sell to";
                        return response;
                    }
                    taxRate = decimal.Parse(fields[3]);
                }

                if (DateTime.Parse(orderDate) > DateTime.Now)
                {
                    response.Success = false;
                    response.Message = "Order must be made for a future date!";
                    return response;
                }
                bool isValid = customerName.All(x => char.IsLetter(x) || x == '.' || x == ',' || char.IsNumber(x));
                if (isValid == false)
                {
                    response.Success = false;
                    response.Message = "You can only use a - z, 0 - 9, and. , for Customer Name!";
                    return response;
                }
                if (area < 100)
                {
                    response.Success = false;
                    response.Message = "You must enter an area 100 or more.";
                    return response;
                }
                reader.Close();

            }
            using (StreamReader reader = new StreamReader(@"C:\Data\FlooringMastery\Products.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {


                    string[] fields = line.Split(',');
                 if(fields[0] != productType)
                    {
                        response.Success = false;
                        response.Message = "that is not a valid product type";
                        return response;
                    }

                    costPerSquareFoot = decimal.Parse(fields[1]);
                    laborCostPerSquareFoot = decimal.Parse(fields[2]);
                  



                }
            }
            response.Success = true;
            order.CustomerName = customerName;
            order.ProductType = productType;
            order.State = state;
            order.TaxRate = taxRate;
            order.OrderDate = orderDate;
            order.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            order.CostPerSquareFoot = costPerSquareFoot;
            order.MaterialCost = (area * costPerSquareFoot);
            order.LaborCost = (area * laborCostPerSquareFoot);
            order.Tax = ((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100));
            order.Total = (order.MaterialCost + order.LaborCost + order.Tax);
            return response;

        }

    }
}

