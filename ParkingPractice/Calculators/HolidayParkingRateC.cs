using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public class HolidayParkingRateC : DayParkingRate
    {
        //全日免費
        public TimeSpan FreeTime => TimeSpan.FromDays(1);

        public int FeeMax => throw new NotImplementedException();

        public TimeSpan UnitTime => throw new NotImplementedException();

        public int GetCurrentFee(int timeRange_index)
        {
            throw new NotImplementedException();
        }
    }
}
