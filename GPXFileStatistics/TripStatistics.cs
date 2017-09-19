using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileStatistics
{
    public class TripStatistics
    {
        public TimeSpan TripTime { get; set; }
        public double Distance { get; set; }

        public double Ascent { get; set; }

        public double Descent { get; set; }
    }
}
