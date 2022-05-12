using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class ParkingRateA : IParkingRate
    {
        public IDayParkingRate Weekday { get; } = new DayParkingRateA();

        public IDayParkingRate Holiday => Weekday;
    }
}
