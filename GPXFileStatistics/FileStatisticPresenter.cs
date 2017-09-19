using System.IO;

namespace GPXFileStatistics
{
    public class FileStatisticPresenter : IStatisticPresenter
    {
        public void PrintStatistics (TripStatistics data)
        {
            string path = "statistics.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Trip Time: {data.TripTime}");
                    sw.WriteLine($"Trip Distance: {data.Distance}");
                    sw.WriteLine($"Trip Ascent: {data.Ascent}");
                    sw.WriteLine($"Trip Descent: {data.Descent}");
                }
            }
        }
    }
}