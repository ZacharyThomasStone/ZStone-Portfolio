using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            List<Order> Orders = new List<Order>();
            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("--------------------------");
            Console.Write("Enter the order date (ex. 01/15/20): ");
            string orderDate = Console.ReadLine();
            Console.Write("Enter order number: ");
            string orderNumber = Console.ReadLine();
          
            bool isValid = false;
            
            Order editedOrder = new Order();


            if (!File.Exists($"C:\\Data\\FlooringMastery\\Orders\\Orders_{orderDate}.txt"))
            {
                Console.WriteLine("There is not an order with that date!");
            }


            using (StreamReader orderReader = new StreamReader($"C:\\Data\\FlooringMastery\\Orders\\Orders_{orderDate}.txt"))
            {
              

                for (var i = 1; i <= int.Parse(orderNumber); i++)
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
                    do
                    {
                        Console.Clear();
                    string[] fields = line.Split(',');
                    string border = "**********************************************************************************************************************";
                    Console.WriteLine(border);
                    Console.WriteLine($"* 1. Customer Name:{fields[1]}");
                    Console.WriteLine($"* 2. State:{fields[2]}");
                    Console.WriteLine($"* 3. Product Type:{fields[4]}");
                    Console.WriteLine($"* 4. Area:{fields[5]}");
                    Console.WriteLine("*");
                    Console.WriteLine(border);
                    Console.WriteLine("What do you want to edit?");
                    string menuChoice = Console.ReadLine();
                        editedOrder.OrderNumber = int.Parse(orderNumber);
                        editedOrder.OrderDate = orderDate;
                        editedOrder.CustomerName = fields[1];
                        editedOrder.State = fields[2];
                        editedOrder.ProductType = fields[4];
                        editedOrder.Area = decimal.Parse(fields[5]);
                        editedOrder.MaterialCost = decimal.Parse(fields[8]);
                        editedOrder.LaborCost = decimal.Parse(fields[9]);
                        editedOrder.Tax = decimal.Parse(fields[10]);
                        editedOrder.Total = decimal.Parse(fields[11]);




                        switch (menuChoice)
                        {
                            case "1":
                                Console.WriteLine("Enter Customer Name:");
                                string nameChange = Console.ReadLine();
                                string userInput;
                                if(nameChange != "")
                                {
                                    Console.WriteLine($"Do you want to change the Customer Name to: {nameChange}, Y or N?:");
                                    userInput = Console.ReadLine();
                                    isValid = nameChange.All(x => char.IsLetter(x) || x == '.' || x == ',' || char.IsNumber(x));
                                if (userInput == "Y" && isValid == true && nameChange != " ")
                                {
                                    fields[1] = nameChange;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"The Customer Name was successfully changed to {fields[1]}.");
                                    Console.ResetColor();
                                    Console.WriteLine("Press any key to continue to main menu...");
                                    Console.ReadKey();
                                    editedOrder.CustomerName = nameChange;
                                    break;
                                }
                                else if (isValid == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You can only use a-z, 0-9, and . , for Customer Name!");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                }
                                if (nameChange == "")
                                {
                                    Console.WriteLine("You didn't enter a name, so the customer name will stay the same.");
                                    nameChange = fields[1];
                                    editedOrder.CustomerName = nameChange;
                                    Console.WriteLine("Press any key to continue to main menu...");
                                    Console.ReadKey();
                                    break;
                                }


                                else
                                {
                                    isValid = false;
                                    Console.Clear();
                                    break;
                                }
                         



                            case "2":
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Enter the order's state abbreviation: ");
                                    Console.ResetColor();
                                    string stateChange = Console.ReadLine();
                                    if (!File.Exists(@"C:\Data\FlooringMastery\Taxes.txt"))
                                    {
                                        Console.WriteLine("Error finding the data file Taxes.txt contact IT.");
                                    }
                                    using (StreamReader readers = new StreamReader(@"C:\Data\FlooringMastery\Taxes.txt"))
                                    {
                                      
                                        isValid = false;
                                        while ((line = readers.ReadLine()) != null && stateChange != "")
                                        {

                                            fields = line.Split(',');
                                            if (fields[0] == stateChange.ToUpper())
                                            {



                                                editedOrder.State = fields[0];
                                                editedOrder.TaxRate = decimal.Parse(fields[2]);
                                               
                                                isValid = true;
                                                break;
                                                





                                            }
                                            else if (fields[1] == stateChange)
                                            {
                                                editedOrder.State = fields[1];
                                                editedOrder.TaxRate = decimal.Parse(fields[2]);
                                                isValid = true;
                                            }
                                        

                                        }
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"State Changed Sucessfully to : {fields[1]}");
                                        Console.ResetColor();
                                        Console.WriteLine("Press any key to continue to main menu...");
                                        Console.ReadKey();
                                        if (isValid == false && stateChange != "")
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"{stateChange} is not one of the states we accept orders from.");
                                            Console.ResetColor();
                                        }
                                        else if (stateChange == "")
                                        {
                                            Console.WriteLine("You didn't enter a new state, so the order state will stay the same.");
                                            editedOrder.State = fields[2];
                                            Console.WriteLine("Press any key to continue to main menu...");
                                            Console.ReadKey();
                                            isValid = true;
                                            break;
                                        }
                                        readers.Close();

                                    }

                                } while (isValid == false);
                                
                          
                               
                                break;
                            case "3":
                                Console.WriteLine("Enter Product Type:");
                                using (StreamReader productReader = new StreamReader(@"C:\Data\FlooringMastery\Products.txt"))
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Clear();
                              
                                    productReader.ReadLine();
                                    List<decimal> LaborCost = new List<decimal>();
                                    List<decimal> CostSquareFoot = new List<decimal>();
                                    int num = 1;
                                    Console.WriteLine(border);
                                    Console.WriteLine("* Choose the product type for your floors: ");
                                    Console.WriteLine("*");

                                    while ((line = productReader.ReadLine()) != null)
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
                                    while (userinput != "")
                                    {
                                        switch (userinput)
                                        {
                                            case "1":

                                                editedOrder.ProductType = "Carpet";
                                                editedOrder.LaborCostPerSquareFoot = LaborCost[0];
                                                editedOrder.CostPerSquareFoot = CostSquareFoot[0];

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"Product Type Changed sucessfully to {editedOrder.ProductType}");
                                                Console.ResetColor();
                                                Console.WriteLine("Press any key to continue to main menu...");
                                                Console.ReadKey();
                                                isValid = true;
                                                break;
                                            case "2":

                                                editedOrder.ProductType = "Laminate";
                                                editedOrder.LaborCostPerSquareFoot = LaborCost[1];
                                                editedOrder.CostPerSquareFoot = CostSquareFoot[1];

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"Product Type Changed sucessfully to {editedOrder.ProductType}");
                                                Console.ResetColor();
                                                Console.WriteLine("Press any key to continue to main menu...");
                                                Console.ReadKey();
                                                isValid = true;
                                                break;
                                            case "3":

                                                editedOrder.ProductType = "Tile";
                                                editedOrder.LaborCostPerSquareFoot = LaborCost[2];
                                                editedOrder.CostPerSquareFoot = CostSquareFoot[2];

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"Product Type Changed sucessfully to {editedOrder.ProductType}");
                                                Console.ResetColor();
                                                Console.WriteLine("Press any key to continue to main menu...");
                                                Console.ReadKey();
                                                isValid = true;
                                                break;
                                            case "4":

                                                editedOrder.ProductType = "Wood";
                                                editedOrder.LaborCostPerSquareFoot = LaborCost[3];
                                                editedOrder.CostPerSquareFoot = CostSquareFoot[3];

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"Product Type Changed sucessfully to {editedOrder.ProductType}");
                                                Console.ResetColor();
                                                Console.WriteLine("Press any key to continue to main menu...");
                                                Console.ReadKey();
                                                isValid = true;
                                                break;
                                            case "5":

                                                isValid = false;
                                                break;


                                        } 
                                    }
                                    if (userinput == "")
                                    {
                                        Console.WriteLine("You didn't enter a new product type, so theproduct type will stay the same.");
                                        editedOrder.ProductType = fields[4];
                                        Console.WriteLine("Press any key to continue to main menu...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    productReader.Close();
                                    break;
                                   
                                }

                      
                            case "4":

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Clear();
                                    Console.WriteLine("Enter area: ");
                                    Console.ResetColor();
                                    int result = 0;
                                    string orderArea = Console.ReadLine();
                                    isValid = false;
                                    int.TryParse(orderArea, out result);
                                    if (result < 100 && orderArea != "")
                                    {
                                        Console.WriteLine("Your order must be at least 100 sq ft!");
                                        Console.ReadKey();
                                    }
                                    else if(result > 100 && orderArea != "")
                                    {
                                        Console.WriteLine($"Area successfully changed to :{result}");
                                        Console.WriteLine("Press any key to continue to main menu...");
                                        Console.ReadKey();
                                        editedOrder.Area = decimal.Parse(orderArea);
                                        editedOrder.MaterialCost = (editedOrder.Area * editedOrder.CostPerSquareFoot);
                                        editedOrder.LaborCost = (editedOrder.Area * editedOrder.LaborCostPerSquareFoot);
                                        editedOrder.Tax = ((editedOrder.MaterialCost + editedOrder.LaborCost) * (editedOrder.TaxRate / 100));
                                        editedOrder.Total = (editedOrder.MaterialCost + editedOrder.LaborCost + editedOrder.Tax);
                                        isValid = true;

                                    }
                                    else
                                    {
                                        Console.WriteLine("You didn't enter a new area, so area will stay the same.");
                                        editedOrder.Area = decimal.Parse(fields[5]);
                                        Console.WriteLine("Press any key to continue to main menu...");
                                        Console.ReadKey();
                                        break;
                                    }
                                } while (isValid == false);
                                isValid = true;
                                break;
                            case "5":

                                isValid = false;
                                break;
                        }
                    } while (isValid == false);
                }

                ConsoleIO.DisplayOrderDetails(editedOrder);
                Console.WriteLine("Would you like to keep these changes?");
                Console.WriteLine("Submit this order? (Y/N)");
                string userChoice = Console.ReadLine();
                orderReader.Close();
                if (userChoice == "Y")
                {
                    string[] lines = System.IO.File.ReadAllLines($"C:\\Data\\FlooringMastery\\Orders\\Orders_{orderDate}.txt");
                    lines[int.Parse(orderNumber)] = ($"{editedOrder.OrderNumber},{editedOrder.CustomerName},{editedOrder.State},{editedOrder.TaxRate},{editedOrder.ProductType},{editedOrder.Area},{editedOrder.CostPerSquareFoot},{editedOrder.LaborCostPerSquareFoot},{editedOrder.MaterialCost},{editedOrder.LaborCost},{editedOrder.Tax},{editedOrder.Total}");
                    System.IO.File.WriteAllLines($"C:\\Data\\FlooringMastery\\Orders\\Orders_{orderDate}.txt", lines);
                }
                else if(userChoice == "N")
                {
                    Console.WriteLine("Changes were not made");
                    Console.ReadKey();
                }

            }
           
            

        }
    }
}
