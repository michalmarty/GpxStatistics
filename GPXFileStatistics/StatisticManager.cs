using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileStatistics
{
    public class StatisticManager
    {
        List<Coordinate> _data;
        TripStatistics _statistics;
        
        public IBikeDataReader DataReader { get; set; }

        public StatisticManager(IBikeDataReader dataReader)
        {
            DataReader = dataReader;
        }

        public TripStatistics CalculateStatistics()
        {
            _data = DataReader.ReadData();
            _statistics = new TripStatistics();
            CalculateTripTime();
            CalculateDistance();
            CalculateTripAscent();
            CalculateTripDescent();
            
            return _statistics;
        }

        
        private void CalculateTripTime()
        {
            _statistics.TripTime = _data.Last().Time - _data.First().Time;
            
        }

        private void CalculateDistance()
        {
            double distance = 0;
            for (int i = 0; i < _data.Count - 2; i++)
            {
                distance += Math.Sqrt(Math.Pow((_data[i + 1].Point.X - _data[i].Point.X), 2) + Math.Pow((_data[i + 1].Point.Y - _data[i].Point.Y), 2));
            }

            _statistics.Distance = distance;
        }

        private void CalculateTripAscent()
        {
            double ascent = 0;
            for (int i = 0; i <_data.Count - 2; i++)
            {
                if (_data[i + 1].Height > _data[i].Height)
                    ascent += _data[i + 1].Height - _data[i].Height;
            }
            _statistics.Ascent = ascent;

        }

        private void CalculateTripDescent()
        {
            double descent = 0;
            for (int i = 0; i < _data.Count - 2; i++)
            {
                if (_data[i + 1].Height < _data[i].Height)
                    descent += _data[i].Height - _data[i+1].Height;
            }
            _statistics.Descent = descent;
        }

    }
}
