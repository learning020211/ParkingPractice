using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    //時段費率
    public class PeriodRate
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan UnitTime { get; set; }
        public int Fee { get; set; }

        public int? FeeMax { get; set; }
    }
}
