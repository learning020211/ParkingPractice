public class ParkingFee
{
    public IEnumerable<SingleDayFee> Items { get; private set; }
    public int TotalFee => Items.Sum(item => item.Fee);

    public ParkingFee(IEnumerable<SingleDayFee> multipleDayFees)
    {
        Items = multipleDayFees;
    }
}

// 單日停車資訊
public class SingleDayFee
{
    public DateTime StartTime { get; set; } // 精確到分鐘的入場時間
    public DateTime EndTime { get; set; } // 精確到分鐘的離場時間
    public int Fee { get; set; } // 本日應收取費用

    public SingleDayFee(DateTime start, DateTime end, Func<DateTime, DateTime, int> getFee)
    {
        StartTime = start;
        EndTime = end;
        Fee = getFee(start, end);
    }
}

public class Solution
{
    #region Q3 計算跨日的停車費
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
        if (currentStart < end)
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
}
