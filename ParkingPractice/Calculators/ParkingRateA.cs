using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateA : ParkingRate
    {
        public DayParkingRate Weekday { get; } = new DayParkingRateA();

        public DayParkingRate Holiday => Weekday;
    }
}
