using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalendarz.src
{
    
    internal class Week
    {
        public Day monday { get; }
        public Day tuesday { get; }
        public Day wednesday { get; }
        public Day thursday { get; }
        public Day friday { get; }
        public Day saturday { get; }
        public Day sunday { get; }

        public Week(List<Day> days)
        {
            monday = days[0];
            tuesday = days[1];
            wednesday = days[2];
            thursday = days[3];
            friday = days[4];
            saturday = days[5];
            sunday = days[6];
        }
    }
}
