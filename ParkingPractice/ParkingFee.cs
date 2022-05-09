public class ParkingFee
{
    public IEnumerable<SingleDayFee> Items { get; private set; }
    public int TotalFee => Items.Sum(item => item.Fee);

    public ParkingFee(IEnumerable<SingleDayFee> multipleDayFees)
    {
        Items = multipleDayFees;
    }
}
