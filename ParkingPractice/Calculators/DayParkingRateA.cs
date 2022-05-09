using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    //每一天都採用目前的收費費率
    public class DayParkingRateA : DayParkingRate
    {
        public TimeSpan FreeTime => TimeSpan.FromMinutes(10);
        public int FeeMax => 50;

        public TimeSpan UnitTime => TimeSpan.FromMinutes(30);

        //前半小時7元, 後半小時3元
        public int GetCurrentFee(int timeRange_index) =>
            timeRange_index % 2 == 0 ? 7 : 3;
    }
}
