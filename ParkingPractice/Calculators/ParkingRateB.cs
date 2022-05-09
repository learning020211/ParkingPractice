using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateB : ParkingRate
    {
        public DayParkingRate Weekday { get; } = new WeekdayParkingRateB();

        public DayParkingRate Holiday { get; } = new HolidayParkingRateB();
    }
}
