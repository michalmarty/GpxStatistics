using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileStatistics
{
    public class Coordinate
    {
        public Point Point { get; set; }

        public double Height { get; set; }

        public DateTime Time { get; set; }

        public static Coordinate Split(string line)
        {
            var kolumna = line.Split(';');
            return new Coordinate
            {
                Point = new Point
                {
                    X = double.Parse(kolumna[4]),
                    Y = double.Parse(kolumna[5]),
                },
                
                Height = double.Parse(kolumna[6]),
                Time = DateTime.Parse(kolumna[7])

            };
        }

        public override string ToString()
        {
            return $"Punkty: {Point} Czas: {Time}";
        }
    }

    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
