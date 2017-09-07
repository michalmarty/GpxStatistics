﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            IBikeDataReader dataReader = new CsvDataReader();

            StatisticManager manager = new StatisticManager(dataReader);

            TripStatistics statistics = manager.CalculateStatistics();

            ConsoleStatisticPresenter presenter = new ConsoleStatisticPresenter();

            presenter.PrintStatistics(statistics);

                      
            Console.ReadKey();

        }




    }
    }
