using PaintFactory.BLL;
using PaintFactory.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFactory.Workflow
{
    public class PaintLookupWorkflow
    {
        public void Execute()
        {
            PaintManager manager = new PaintManager();
            PaintLookupResponse response;

            Console.WriteLine("------------------------");
            Console.Write("\nEnter selection: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "Q":
                    return;
                default:
                    response = manager.LookupPaint(userInput);
                    break;
            }
            
            if (response.Success)
            {
                ConsoleIO.DisplayPaintDetails(response.Paint);
            } 
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Execute();
        }
        public void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Paint Manager");
            Console.WriteLine("------------------------");
            Console.WriteLine("\nQ to quit manager");
            Console.WriteLine("Enter a number of days from today");
        }
    }
}
