/// <summary>
/// 單日停車資訊
/// </summary>
public class SingleDayFee : UnitFee
{
    public SingleDayFee(DateTime start, DateTime end, Func<DateTime, DateTime, int> getFee)
    {
        StartTime = start;
        EndTime = end;
        Fee = getFee(start, end);
    }
}
