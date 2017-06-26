using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
           string orderDate;
            Order tempOrder = new Order();
            List<Order> Orders = new List<Order>();
            bool isValid = false;
            string customerName;
            string userInput;
            Console.WriteLine("Add Order");


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter Order Date (example format - 01/15/20): ");
                Console.ResetColor();
                orderDate = Console.ReadLine();
         
                Console.Clear();


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter Customer Name: ");
                Console.ResetColor();
                customerName = Console.ReadLine();
          

    
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter the order's state abbreviation: ");
                Console.ResetColor();
                string orderState = Console.ReadLine();
                if (!File.Exists(@"C:\Data\FlooringMastery\Taxes.txt"))
                {
                    Console.WriteLine("Error finding the data file Taxes.txt contact IT.");
                }
           
                 

        
            if (!File.Exists(@"C:\Data\FlooringMastery\Products.txt"))
            {
                Console.WriteLine("Error finding the data file Products.txt contact IT.");
            }
    
                using (StreamReader reader = new StreamReader(@"C:\Data\FlooringMastery\Products.txt"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    string line;
                    string[] fields;
                    reader.ReadLine();
                    List<decimal> LaborCost = new List<decimal>();
                    List<decimal> CostSquareFoot = new List<decimal>();
                    int num = 1;
                    string border = "**********************************************************************************************************************";
                    Console.WriteLine(border);
                    Console.WriteLine("* Choose the product type for your floors: ");
                    Console.WriteLine("*");


                    while ((line = reader.ReadLine()) != null)
                    {


                        fields = line.Split(',');
                        Console.WriteLine($"* {num}. {fields[0]} ");

                        LaborCost.Add(decimal.Parse(fields[2]));
                        CostSquareFoot.Add(decimal.Parse(fields[1]));
                        num++;




                    }




                    Console.WriteLine(border);
                    string userinput = Console.ReadLine();
                    isValid = false;
                    switch (userinput)
                    {
                        case "1":

                            tempOrder.ProductType = "Carpet";
                            tempOrder.LaborCostPerSquareFoot = LaborCost[0];
                            tempOrder.CostPerSquareFoot = CostSquareFoot[0];
                            isValid = true;
                            break;
                        case "2":

                            tempOrder.ProductType = "Laminate";
                            tempOrder.LaborCostPerSquareFoot = LaborCost[1];
                            tempOrder.CostPerSquareFoot = CostSquareFoot[1];
                            isValid = true;
                            break;
                        case "3":

                            tempOrder.ProductType = "Tile";
                            tempOrder.LaborCostPerSquareFoot = LaborCost[2];
                            tempOrder.CostPerSquareFoot = CostSquareFoot[2];
                            isValid = true;
                            break;
                        case "4":

                            tempOrder.ProductType = "Wood";
                            tempOrder.LaborCostPerSquareFoot = LaborCost[3];
                            tempOrder.CostPerSquareFoot = CostSquareFoot[3];
                            isValid = true;
                            break;
                        case "5":
                        
                            isValid = false;
                            break;


                    }
                    
                   if (isValid == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That is not a valid choice!");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                    }
                 
                } 
        
            Console.ResetColor();

            do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    Console.WriteLine("Enter area: ");
                    Console.ResetColor();
                    string orderArea = Console.ReadLine();
                    isValid = false;
                    if (int.Parse(orderArea) < 100)
                    {
                        Console.WriteLine("Your order must be at least 100 sq ft!");
                        Console.ReadKey();
                    }
                    else
                    {
                      
                        tempOrder.Area = decimal.Parse(orderArea);
                        tempOrder.MaterialCost = (tempOrder.Area * tempOrder.CostPerSquareFoot);
                        tempOrder.LaborCost = (tempOrder.Area * tempOrder.LaborCostPerSquareFoot);
                        tempOrder.Tax = ((tempOrder.MaterialCost + tempOrder.LaborCost) * (tempOrder.TaxRate / 100));
                        tempOrder.Total = (tempOrder.MaterialCost + tempOrder.LaborCost + tempOrder.Tax);
                        isValid = true;

                    }
                } while (isValid == false);

      
    

                Orders.Add(tempOrder);
               
             
            
            do
            {
                ConsoleIO.DisplayOrderDetails(tempOrder);
                Console.WriteLine("Submit this order? (Y/N)");
                userInput = Console.ReadLine();
                if (userInput.ToUpper() == "Y")
                {

                   
                  
                    if (!File.Exists($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt"))
                    {
                        File.Create($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt").Close();
                        File.WriteAllText($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt", "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                        tempOrder.OrderNumber = 1;
                    }
                    else if(File.Exists($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt"))
                    {
                        var lastline = File.ReadLines($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt").Last();
                        string[] fields = lastline.Split(',');
                        tempOrder.OrderNumber = int.Parse(fields[0]) + 1;
                    }

                    using (FileStream fs = new FileStream($"C:\\Data\\FlooringMastery\\Orders\\Orders_{tempOrder.OrderDate}.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter writer = new StreamWriter(fs))
                    {

                        writer.WriteLine($"{tempOrder.OrderNumber},{tempOrder.CustomerName},{tempOrder.State},{tempOrder.TaxRate},{tempOrder.ProductType},{tempOrder.Area},{tempOrder.CostPerSquareFoot},{tempOrder.LaborCostPerSquareFoot},{tempOrder.MaterialCost},{tempOrder.LaborCost},{tempOrder.Tax},{tempOrder.Total}");
                    }
                    Console.WriteLine("Your order has been added successfully!");
                    Orders.Add(tempOrder);
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    isValid = true;
                }

                else if (userInput.ToUpper() == "N")
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid choice");
                    Console.ResetColor();
                    isValid = false;
                    
                } 
            } while (isValid == false);


        }
        
    }
}

