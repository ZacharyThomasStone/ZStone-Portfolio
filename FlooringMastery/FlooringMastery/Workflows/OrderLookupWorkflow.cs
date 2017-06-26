using FlooringMaster.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Globalization;

namespace FlooringMastery.Workflows
{
    public class OrderLookupWorkflow
    {
        public void Execute ()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an order");
            Console.WriteLine("--------------------------");
            Console.Write("Enter an order date: ");
            string orderDate = Console.ReadLine();
            Console.Write("Enter an order number: ");
            int orderNumber = int.Parse(Console.ReadLine());

            OrderLookupResponse response = manager.LookupOrder(orderNumber, orderDate);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    
    
}
