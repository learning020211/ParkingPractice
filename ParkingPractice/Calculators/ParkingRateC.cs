using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateC : ParkingRate
    {
        public DayParkingRate Weekday { get; } = new WeekdayParkingRateC();

        public DayParkingRate Holiday { get; } = new HolidayParkingRateC();
    }
}
