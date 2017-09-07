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
        double _eQuatorialEarthRadius = 6378.1370D;
        double _d2r = (Math.PI / 180D);

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

                double dlong = (_data[i + 1].Point.X - _data[i].Point.X) * _d2r;
                double dlat = (_data[i + 1].Point.Y - _data[i].Point.Y) * _d2r;
                double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(_data[i].Point.X * _d2r) * Math.Cos(_data[i + 1].Point.X * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
                double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
                distance += _eQuatorialEarthRadius * c;
            }

            _statistics.Distance = distance;

        }

        private void CalculateTotalAscent()
        {
            double height = 0;
            for (int i = 0; i < _data.Count - 2; i++)
            {
                if (_data[i + 1].Height > _data[i].Height)
                    height += _data[i + 1].Height - _data[i].Height;
            }
            _statistics.Ascent = height;
        }

        private void CalculateTotalDescent()
        {
            double height = 0;
            for (int i = 0; i < _data.Count - 2; i++)
            {
                if (_data[i + 1].Height < _data[i].Height)
                    height += _data[i].Height - _data[i + 1].Height;
            }
            _statistics.Descent = height;
        }

        private void CheckStartTime()
        {
            _statistics.StartTime = Convert.ToDateTime(_data.First().Time);
        }
    }
}
