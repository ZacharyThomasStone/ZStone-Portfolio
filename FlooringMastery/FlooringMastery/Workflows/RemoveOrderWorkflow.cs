using System;
using System.IO;
using FlooringMastery.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.WriteLine("Enter the date of the order you want to delete:");
            string removeDate = Console.ReadLine();
            Console.WriteLine("Enter the order number of the order you want to delete:");
            string removeOrderNumber = Console.ReadLine();
       

            Order orderToDelete = new Order();

            if (!File.Exists($"C:\\Data\\FlooringMastery\\Orders\\Orders_{removeDate}.txt"))
            {
                Console.WriteLine("There is not an order with that date!");
            }

            using (StreamReader orderReader = new StreamReader($"C:\\Data\\FlooringMastery\\Orders\\Orders_{removeDate}.txt"))
            {


                for (var i = 1; i <= int.Parse(removeOrderNumber); i++)
                {
                    orderReader.ReadLine();
                }
                string line = orderReader.ReadLine();


                if (line == null)
                {
                    Console.WriteLine("That order does not exist!");

                }
                if (line != null)
                {
                    string[] fields = line.Split(',');
                    orderToDelete.OrderNumber = int.Parse(fields[0]);
                    orderToDelete.CustomerName = fields[1];
                    orderToDelete.State = fields[2];
                    orderToDelete.OrderDate = removeDate;
                    orderToDelete.ProductType = fields[4];
                    orderToDelete.MaterialCost = decimal.Parse(fields[8]);
                    orderToDelete.LaborCost = decimal.Parse(fields[9]);
                    orderToDelete.Tax = decimal.Parse(fields[10]);
                    orderToDelete.Total = decimal.Parse(fields[11]);

                }
                orderReader.Close();
                ConsoleIO.DisplayOrderDetails(orderToDelete);
                Console.WriteLine("Are you sure you want to delete this order? Y or N?");
                string userInput = Console.ReadLine();
                if (userInput == "Y")
                {
                    string[] lines = System.IO.File.ReadAllLines($"C:\\Data\\FlooringMastery\\Orders\\Orders_{removeDate}.txt");
                    lines[int.Parse(removeOrderNumber)] = "";
                    System.IO.File.WriteAllLines($"C:\\Data\\FlooringMastery\\Orders\\Orders_{removeDate}.txt", lines);
                    Console.WriteLine("The order was deleted");
                }
                else
                {
                    Console.WriteLine("The order was not deleted.");
                }





            }
        }
    }
}
