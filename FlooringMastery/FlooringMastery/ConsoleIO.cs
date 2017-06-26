using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            string border = "**********************************************************************************************************************";
            Console.WriteLine(border);
            Console.WriteLine($"Order Number: {order.OrderNumber}  |  Order Date: {order.OrderDate}");
            Console.WriteLine($"Customer Name: {order.CustomerName}                    Order State: {order.State}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine(String.Format("Material Cost: {0:C}",order.MaterialCost));
            Console.WriteLine(String.Format("Labor Cost: {0:C}",order.LaborCost));
            Console.WriteLine(String.Format("Tax: {0:C}",order.Tax));
            Console.WriteLine(String.Format("Total : {0:C}",order.Total));

        }
        public static void DisplayEditMenu(Order order)
        {
            string border = "**********************************************************************************************************************";
            Console.WriteLine(border);
            Console.WriteLine($"* 1. Customer Name:{order.CustomerName}");
            Console.WriteLine($"* 2. State:{order.State}");
            Console.WriteLine($"* 3. Product Type:{order.State}");
            Console.WriteLine($"* 4. Area:{order.Area}");
            Console.WriteLine("*");
            Console.WriteLine(border);
            Console.WriteLine("What do you want to edit?");
        }
    }
}
