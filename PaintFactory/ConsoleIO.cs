using PaintFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFactory
{
    public class ConsoleIO
    {
        public static void DisplayPaintDetails(Paint paint)
        {
            //Console.WriteLine($"Day: {paint.Day}");
            Console.WriteLine($"Paint Color: {paint.Color}");
        }
    }
}
