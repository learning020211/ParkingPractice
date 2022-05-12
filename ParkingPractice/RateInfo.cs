using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice
{
    public class RateInfo
    {

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public int Fee { get; set; }
        public TimeSpan UnitTime { get; set; }
    }
}
