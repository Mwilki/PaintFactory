using PaintFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaintFactory.Data
{
    public class PaintRepository
    {
        public string ColorOfTheDay(int days)
        {
            string colorValue;
            List<Paint> paints = GetPaints();
            int daysInWeek = GetDaysInWeek();
            // starting at 0 makes the sunday math more complicated.  Add 1 to calculate remainder. 
            Int64 daysTranslated = days + 1; // make Int64 incase they decide to pass in the max value of an Int32 ...

            // If remainder = 0, it's sunday
            if (daysTranslated % daysInWeek == 0)
            {
                colorValue = "NA";
            }
            else
            {
                // how many sundays have we skipped?
                // do not round up when calculating how many sundays have elapsed
                int sundaysSkipped = (int)Math.Floor((decimal)(daysTranslated / daysInWeek));
                // 7 days after monday = 1 sunday
                // 33 days after monday = 4 sundays

                // to get the correct color, we have to consider all of the days we didnt work, so we can retain the current color order    
                int offsetNumber = (days - sundaysSkipped);

                // Now find remainder between offset-number and the # of days in a week
                int newColorIndex = (offsetNumber % daysInWeek);

                colorValue = paints[newColorIndex].Color;
            }
            return colorValue;
        }

        public List<Paint> GetPaints()
        {
            List<Paint> paints = new List<Paint>();
            // alternative:  create a lookup sql table that stores paint colors
            string[] colors = new string[] { "red", "yellow", "blue", "green", "purple", "black", "white" };

            foreach (string color in colors)
            {
                Paint paint = new Paint
                {
                    Color = color
                };
                paints.Add(paint);
            }
            return paints;
        }

        public int GetDaysInWeek()
        {
            // alternative: create a constants sql table with two columns (id, value).  Or use a non relational database (mongoDB) to store key/value pairs - i.e. daysInWeek : 7
            return 7;
        }

        // overkill?  Future enhancement :  Paint object could have some other properties in the future we would like to initialize.. day of week (1st,27th), title of day (tuesday,friday,ect)
        public Paint LoadPaint()
        {
            return new Paint();
        }
    }
}
