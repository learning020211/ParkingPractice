using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateC : IParkingRate
    {
        public IDayParkingRate Weekday { get; } = new WeekdayParkingRateC();

        public IDayParkingRate Holiday { get; } = new HolidayParkingRateC();
    }
}
