using ParkingPractice.Calculators;

public class Solution
{
    #region self practice
    /// <summary>
    /// 計算同一區間費率, 開始時間一定落在區間範圍內
    /// </summary>
    /// <param name="rate">區間費率</param>
    /// <param name="startTime">開始時間</param>
    /// <param name="endTime">結束時間</param>
    /// <returns>單位時間收費資訊</returns>
    public IEnumerable<UnitFee> CalcPeriodFee(PeriodRate rate, DateTime startTime, DateTime endTime)
    {
        //捨去到分
        startTime = startTime.SkipToMinutes();
        endTime = endTime.SkipToMinutes();

        //計算的相對時間範圍
        var start = startTime.TimeOfDay;
        var end = start + (endTime - startTime);

        var rateEnd = rate.EndTime;
        //跨日
        if (rateEnd < rate.StartTime) rateEnd = rate.EndTime.Add(TimeSpan.FromDays(1));
        if (rateEnd < end) end = rateEnd;
        
        DateTime getTime(TimeSpan timeSpan) =>
            startTime + (timeSpan - start);

        List<UnitFee> fees = new List<UnitFee>();

        //區間收費上限
        int remain = rate.FeeMax ?? int.MaxValue;

        for (var current = start;
            current < end;
            current += rate.UnitTime //每次向後移動單位時間
            )
        {
            //計算上限內的上限費用
            int fee = Math.Min(rate.Fee, remain);
            remain -= fee;

            fees.Add(new UnitFee()
            {
                StartTime = getTime(current),
                EndTime = getTime(current + rate.UnitTime),
                Fee = fee
            });

            if (remain <= 0)
            {
                //超出上限不再計算, 日後有需要再改成加入 0 元的單位費用
                break;
            }
        }

        return fees;
    }
    #endregion

    #region Q4 支援不同停車場的收費原則
    public ParkingFee CalcParkingFee(IParkingRate rate, DateTime start, DateTime end)
    {
        if (end < start) throw new ArgumentException();
        //捨去到分
        start = start.SkipToMinutes();
        end = end.SkipToMinutes();

        List<SingleDayFee> fees = new List<SingleDayFee>();

        DateTime currentStart = start;
        DateTime getCurrentEndTime() => currentStart.DateEnd().CompareAndTakeSmaller(end);
        DateTime currentEnd = getCurrentEndTime();

        void shiftNextDay()
        {
            currentStart = currentStart.NextDateStart();
            currentEnd = getCurrentEndTime();
        };


        while (currentStart <= end)
        {
            var dayRate = rate.GetRateByDate(currentStart);

            fees.Add(
                new SingleDayFee(
                    currentStart,
                    currentEnd,
                    (currentStart, currentEnd) => CalcFee(dayRate, currentStart, currentEnd)
                ));

            shiftNextDay();
        }

        return new ParkingFee(fees);
    }

    private int CalcFee(IDayParkingRate rate, DateTime start, DateTime end)
    {
        var stay = end - start;
        //免費時段內不收費
        if (stay <= rate.FreeTime) return 0;

        int timeRange_index = 0; //當日第幾個費率時段
        int total = 0;

        for (var currentTime = start;
            currentTime < end;
            currentTime += rate.UnitTime, //每次向後移動單位時間
            timeRange_index ++
            )
        {
            total += rate.GetCurrentFee(timeRange_index); //累計單位時間費用
            //到達最高收費, 不再計算
            if (total >= rate.FeeMax) return rate.FeeMax;
        }
        return total;
    }
    #endregion

    #region Q3 計算跨日的停車費
    [Obsolete("使用 CalcParkingFee(ParkingRate rate, DateTime start, DateTime end) 可支援不同停車場的收費原則")]
    public ParkingFee CalcParkingFee(DateTime start, DateTime end)
    {
        if (end < start) throw new ArgumentException();

        start = start.SkipToMinutes();
        end = end.SkipToMinutes();

        List<SingleDayFee> fees = new List<SingleDayFee>();

        var currentStart = start;
        var currentEnd = start.DateEnd().CompareAndTakeSmaller(end);

        //第一天
        fees.Add(new SingleDayFee(currentStart, currentEnd, CalcFee));
        void shiftNextDay()
        {
            currentStart = currentStart.NextDateStart();
            currentEnd = currentStart.DateEnd();
        };
        //中間天數
        for (shiftNextDay();
            currentEnd < end;
            shiftNextDay())
            fees.Add(new SingleDayFee(currentStart, currentEnd, (_, _) => FEE_MAX));
        //最後一日
        if (currentStart <= end)
        {
            currentEnd = currentEnd.CompareAndTakeSmaller(end);
            fees.Add(new SingleDayFee(currentStart, currentEnd, CalcFee));
        }

        return new ParkingFee(fees);

    }
    #endregion

    #region Q2 計算單日的停車費
    //免費時段
    private readonly TimeSpan FREE_TIME = TimeSpan.FromMinutes(10);
    //最高收費
    private const int FEE_MAX = 50;
    //觀察題目規律, 每小時 10 元, 前半小時 7 元, 後半小時 3 元
    private const int FEE_HOUR = 10;
    private const int FEE_FIRST_HALF_HOUR = 7;

    public int CalcFee(DateTime start, DateTime end)
    {
        //捨去到分
        start = start.SkipToMinutes();
        end = end.SkipToMinutes();

        var stay = end - start;
        //免費時段內不收費
        if (stay <= FREE_TIME) return 0;

        //總時數費用
        var fee = (int)stay.TotalHours * FEE_HOUR;
        //剩餘未滿一小時費用
        if (stay.Minutes > 0) fee += (int)stay.Minutes <= 30 ? FEE_FIRST_HALF_HOUR : FEE_HOUR;
        //檢查最高收費
        return Math.Min(FEE_MAX, fee);
    }
    #endregion

    #region Q1 計算停車分鐘數
    public int GetStayMinutes(DateTime start, DateTime end) =>
        (int)(end.SkipToMinutes() - start.SkipToMinutes()).TotalMinutes;
    #endregion
}

public static class Extensions
{
    public static DateTime SkipToMinutes(this DateTime dateTime) =>
        dateTime.Date.AddMinutes((int)dateTime.TimeOfDay.TotalMinutes);
    public static DateTime NextDateStart(this DateTime dateTime) =>
        dateTime.Date.AddDays(1);
    public static DateTime DateEnd(this DateTime dateTime) =>
        dateTime.NextDateStart().AddMinutes(-1);
    public static DateTime CompareAndTakeSmaller(this DateTime dateTime, DateTime dateTimeToCompare) =>
        dateTime < dateTimeToCompare ? dateTime : dateTimeToCompare;

    public static IDayParkingRate GetRateByDate(this IParkingRate rate, DateTime dateTime) =>
        dateTime.DayOfWeek switch
        {
            DayOfWeek.Saturday => rate.Holiday,
            DayOfWeek.Sunday => rate.Holiday,
            _ => rate.Weekday
        };
}
