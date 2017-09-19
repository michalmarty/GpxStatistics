using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileStatistics
{
    public class ConsoleStatisticPresenter : IStatisticPresenter
    {
        public void PrintStatistics(TripStatistics data)
        {
            Console.WriteLine($"_____________________________________");
            Console.WriteLine($"|Parameter     |Value      |Unit    |");
            Console.WriteLine($"_____________________________________");
            Console.WriteLine($"|Trip time     |{data.TripTime}| hh:mm:ss|");
            Console.WriteLine($"|Ascent        |{data.Ascent}  | m|");
            Console.WriteLine($"|Descent       |{data.Descent} | m|");
        }

       
    }
}
