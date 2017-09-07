using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GPXFileStatistics
{
    public class CsvDataReader : IBikeDataReader
    {
        public List<Coordinate> ReadData()
        {
            var points = ReadPoints("activity.csv");
            return points;
        }

        private List<Coordinate> ReadPoints(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Coordinate.Split)
                .ToList();
        }
    }
}
