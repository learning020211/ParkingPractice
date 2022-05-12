using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateB : IParkingRate
    {
        public IDayParkingRate Weekday { get; } = new WeekdayParkingRateB();

        public IDayParkingRate Holiday { get; } = new HolidayParkingRateB();
    }
}
