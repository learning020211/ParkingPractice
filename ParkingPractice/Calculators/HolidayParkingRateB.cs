using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class HolidayParkingRateB : IDayParkingRate
    {
        public TimeSpan FreeTime => TimeSpan.Zero;
        public int FeeMax => 250;

        public TimeSpan UnitTime => TimeSpan.FromHours(1);

        public int GetCurrentFee(int timeRange_index) =>
            15;
    }
}
