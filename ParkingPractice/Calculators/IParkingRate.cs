using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public interface IParkingRate
    {
        IDayParkingRate Weekday { get; }
        IDayParkingRate Holiday { get; }
    }
}
