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
            Console.WriteLine($"Start time: {data.StartTime}");
            Console.WriteLine($"_________________________________________");
            Console.WriteLine($"|Parameter     |Value          |Unit     |");
            Console.WriteLine($"__________________________________________");
            Console.WriteLine($"|Trip time     |{data.TripTime}| hh:mm:ss|");
            Console.WriteLine($"|Distance      |{data.Distance}| km      |");
            Console.WriteLine($"|Ascent        |{data.Ascent}  | m       |");
            Console.WriteLine($"|Descent       |{data.Descent} | m       |");
        }

       
    }
}
