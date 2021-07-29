using PaintFactory.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFactory
{
    class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vehicle Paint Factory");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Lookup Paint Schedule");
                Console.WriteLine("2. Quit your Job");
                Console.WriteLine("\nQ to quit application");

                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        PaintLookupWorkflow lookupWorkflow = new PaintLookupWorkflow();
                        lookupWorkflow.DisplayTitle();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        Console.WriteLine("No severance package for you!");
                        Console.ReadLine();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("You must enter a valid selection, try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
