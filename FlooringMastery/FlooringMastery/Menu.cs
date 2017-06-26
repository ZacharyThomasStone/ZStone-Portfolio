using FlooringMastery.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery
{
   public static class Menu
    {
       
        public static void Start()
        {
            string border = "**********************************************************************************************************************";
            while (true)
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("* Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an Order");
                Console.WriteLine("* 3. Edit an Order");
                Console.WriteLine("* 4. Remove an Order");
                Console.WriteLine("*");
                Console.WriteLine("* 5. Quit");
                Console.WriteLine("*");
                Console.WriteLine(border);

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrder = new AddOrderWorkflow();
                        addOrder.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrder = new EditOrderWorkflow();
                        editOrder.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrder = new RemoveOrderWorkflow();
                        removeOrder.Execute();
                        break;
                    case "5":
                        return;
                }

            }
        }
    }
}
