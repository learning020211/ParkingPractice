using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public interface ParkingRate
    {
        DayParkingRate Weekday { get; }
        DayParkingRate Holiday { get; }
    }
}
