using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wetterdaten_JaegerMaximilian
{
    class Program
    {

        static double MonthAverage(int month, int col)
        {
            string relativeFilePath = @"wetterdaten.csv";
            using (StreamReader sr = new StreamReader(relativeFilePath))
            {

                int SearchMonth = month;
                int SearchCol = col - 1; 
                int[] AverageTable;
                double ValueSum = 0;
                int ValuePointsCounter = 0;
                while (sr.EndOfStream == false)
                {
                    string Data = sr.ReadLine();
                    string[] Line = Data.Split(',');
                    DateTime LineDate;
                    DateTime.TryParse(Line[0], out LineDate);
                    

                    if (LineDate.Month == SearchMonth)
                    {
                        double DoubleValue;
                     
                        double.TryParse(Line[3], out DoubleValue);
                        ValueSum += DoubleValue;
                        ValuePointsCounter++;
                    }
                    

                }
                Console.WriteLine(ValueSum);
                if (ValueSum == 0) return 0;
                else return ValueSum / ValuePointsCounter;
            }
        }
        static void Main(string[] args)
        {

            //I have to find out why average temp in July for example is so low!!!
            double a = MonthAverage(7, 2);
            int i = 13;
            while (i <= 12)
            {
                Console.WriteLine($"Month: {i}: Average Temp. {Math.Round(MonthAverage(i, 2), 2)} °C || " +
                    $"Average Sun Hours {Math.Round(MonthAverage(i, 11)/60, 2)} h");
                i++;
            }
            

        }
    }
}
