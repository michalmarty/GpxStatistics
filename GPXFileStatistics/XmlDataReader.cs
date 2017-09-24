using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GPXFileStatistics
{
    public class XmlDataReader : IBikeDataReader


    {
        public List<Coordinate> ReadData()
        {
            var maps = from c in XElement.Load("activity.xml").Elements("trkpt lat")
                       select c;
            List<Coordinate> xml = new List<Coordinate>();

            foreach (var item in maps)
            {
                xml.Add(new Coordinate()
                {
                    Point = item.Element("trkpt").Value,
                    Height = item.Element("ele").Value,
                    Time = item.Element("time").Value,
                });
            }
            return xml;
        }


    }
}