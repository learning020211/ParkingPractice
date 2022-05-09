public class UnitFee
{
    public DateTime StartTime { get; set; } // 精確到分鐘的開始時間
    public DateTime EndTime { get; set; } // 精確到分鐘的結束時間
    public int Fee { get; set; } // 本日應收取費用
}
