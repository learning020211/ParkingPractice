using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Calculators
{
    public interface IDayParkingRate
    {
        /// <summary>
        /// 免費時間
        /// </summary>
        TimeSpan FreeTime { get; }
        /// <summary>每日最高收費</summary>
        int FeeMax { get; }
        /// <summary>每次向後移動單位時間</summary>
        TimeSpan UnitTime { get; }
        /// <summary>取得當前時段費用</summary>
        /// <param name="timeRange_index">本日第幾個時段</param>
        /// <returns>當前時段費用</returns>
        int GetCurrentFee(int timeRange_index);

    }
}
