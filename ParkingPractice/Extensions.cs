using ParkingPractice.Calculators;

public static class Extensions
{
    public static DateTime SkipToMinute(this DateTime dateTime) =>
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
