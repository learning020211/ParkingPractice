using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        [DataRow("00:00:00", "23:59:59", 50, DisplayName = "全天\t50")]
        [DataRow("09:00:00", "09:00:00", 0, DisplayName = "[0, 10] = 0")]
        [DataRow("09:00:00", "09:10:59", 0, DisplayName = "[0, 10] = 0")]
        [DataRow("09:00:00", "09:11:00", 7, DisplayName = "[11, 30] = 7")]
        [DataRow("09:00:00", "09:30:59", 7, DisplayName = "[11, 30] = 7")]
        [DataRow("09:00:00", "09:31:00", 10, DisplayName = "[31, 59] = 10")]
        [DataRow("09:00:00", "09:59:59", 10, DisplayName = "[31, 59] = 10")]
        [DataRow("09:00:00", "10:00:59", 10, DisplayName = "[60] = 10")]
        [DataRow("09:00:00", "10:01:00", 17, DisplayName = "[61, 90] = 17")]
        [DataRow("09:00:00", "10:30:59", 17, DisplayName = "[61, 90] = 17")]
        [DataRow("09:00:00", "10:31:00", 20, DisplayName = "[91, 119] = 20")]
        [DataRow("09:00:00", "10:59:59", 20, DisplayName = "[91, 119] = 20")]
        [DataRow("09:00:00", "11:00:59", 20, DisplayName = "[120] = 20")]
        [DataRow("09:00:00", "11:01:00", 27, DisplayName = "[121, 150] = 27")]
        [DataRow("09:00:00", "11:30:59", 27, DisplayName = "[121, 150] = 27")]
        [DataRow("09:00:00", "11:31:00", 30, DisplayName = "[151, 179] = 30")]
        [DataRow("09:00:00", "11:59:59", 30, DisplayName = "[151, 179] = 30")]
        [DataRow("09:00:00", "12:00:59", 30, DisplayName = "[180] = 30")]
        [DataRow("09:00:00", "12:01:00", 37, DisplayName = "[181, 210] = 37")]
        [DataRow("09:00:00", "12:30:59", 37, DisplayName = "[181, 210] = 37")]
        [DataRow("09:00:00", "12:31:00", 40, DisplayName = "[211, 239] = 40")]
        [DataRow("09:00:00", "12:59:59", 40, DisplayName = "[211, 239] = 40")]
        [DataRow("09:00:00", "13:00:59", 40, DisplayName = "[240] = 40")]
        [DataRow("09:00:00", "13:01:00", 47, DisplayName = "[241, 270] = 47")]
        [DataRow("09:00:00", "13:30:59", 47, DisplayName = "[241, 270] = 47")]
        [DataRow("09:00:00", "13:31:00", 50, DisplayName = "[271, 299] = 50")]
        [DataRow("09:00:00", "13:59:59", 50, DisplayName = "[271, 299] = 50")]
        [DataRow("09:00:00", "14:00:59", 50, DisplayName = "[300] = 50")]
        [DataRow("09:00:00", "14:01:00", 50, DisplayName = "[301, 330] = 50")]
        [DataRow("09:00:00", "14:30:59", 50, DisplayName = "[301, 330] = 50")]
        [DataRow("09:00:00", "14:31:00", 50, DisplayName = "[331, 359] = 50")]
        [DataRow("09:00:00", "14:59:59", 50, DisplayName = "[331, 359] = 50")]
        [DataRow("09:00:00", "15:00:59", 50, DisplayName = "[360] = 50")]
        public void CalcFeeTest(string start, string end, int expect)
        {
            Solution solution = new Solution();
            int res = solution.CalcFee(DateTime.Parse(start), DateTime.Parse(end));
            Assert.AreEqual(expect, res);
        }

        [TestMethod()]
        [DataRow("00:00:00", "23:59:59", 50, DisplayName = "全天\t50")]
        [DataRow("09:00:00", "09:00:00", 0, DisplayName = "[0, 10] = 0")]
        [DataRow("09:00:00", "09:10:59", 0, DisplayName = "[0, 10] = 0")]
        [DataRow("09:00:00", "09:11:00", 7, DisplayName = "[11, 30] = 7")]
        [DataRow("09:00:00", "09:30:59", 7, DisplayName = "[11, 30] = 7")]
        [DataRow("09:00:00", "09:31:00", 10, DisplayName = "[31, 59] = 10")]
        [DataRow("09:00:00", "09:59:59", 10, DisplayName = "[31, 59] = 10")]
        [DataRow("09:00:00", "10:00:59", 10, DisplayName = "[60] = 10")]
        [DataRow("09:00:00", "10:01:00", 17, DisplayName = "[61, 90] = 17")]
        [DataRow("09:00:00", "10:30:59", 17, DisplayName = "[61, 90] = 17")]
        [DataRow("09:00:00", "10:31:00", 20, DisplayName = "[91, 119] = 20")]
        [DataRow("09:00:00", "10:59:59", 20, DisplayName = "[91, 119] = 20")]
        [DataRow("09:00:00", "11:00:59", 20, DisplayName = "[120] = 20")]
        [DataRow("09:00:00", "11:01:00", 27, DisplayName = "[121, 150] = 27")]
        [DataRow("09:00:00", "11:30:59", 27, DisplayName = "[121, 150] = 27")]
        [DataRow("09:00:00", "11:31:00", 30, DisplayName = "[151, 179] = 30")]
        [DataRow("09:00:00", "11:59:59", 30, DisplayName = "[151, 179] = 30")]
        [DataRow("09:00:00", "12:00:59", 30, DisplayName = "[180] = 30")]
        [DataRow("09:00:00", "12:01:00", 37, DisplayName = "[181, 210] = 37")]
        [DataRow("09:00:00", "12:30:59", 37, DisplayName = "[181, 210] = 37")]
        [DataRow("09:00:00", "12:31:00", 40, DisplayName = "[211, 239] = 40")]
        [DataRow("09:00:00", "12:59:59", 40, DisplayName = "[211, 239] = 40")]
        [DataRow("09:00:00", "13:00:59", 40, DisplayName = "[240] = 40")]
        [DataRow("09:00:00", "13:01:00", 47, DisplayName = "[241, 270] = 47")]
        [DataRow("09:00:00", "13:30:59", 47, DisplayName = "[241, 270] = 47")]
        [DataRow("09:00:00", "13:31:00", 50, DisplayName = "[271, 299] = 50")]
        [DataRow("09:00:00", "13:59:59", 50, DisplayName = "[271, 299] = 50")]
        [DataRow("09:00:00", "14:00:59", 50, DisplayName = "[300] = 50")]
        [DataRow("09:00:00", "14:01:00", 50, DisplayName = "[301, 330] = 50")]
        [DataRow("09:00:00", "14:30:59", 50, DisplayName = "[301, 330] = 50")]
        [DataRow("09:00:00", "14:31:00", 50, DisplayName = "[331, 359] = 50")]
        [DataRow("09:00:00", "14:59:59", 50, DisplayName = "[331, 359] = 50")]
        [DataRow("09:00:00", "15:00:59", 50, DisplayName = "[360] = 50")]
        [DataRow("2002/5/1 23:50:00", "2002/5/2 00:10:59", 0, DisplayName = "跨1天,時間極短")]
        [DataRow("2002/5/1 23:48:00", "2002/5/2 00:11:59", 14, DisplayName = "跨1天,必需付費")]
        [DataRow("2002/5/1 23:48:00", "2002/5/3 00:11:59", 64, DisplayName = "跨2天,必需付費")]
        public void CalcParkingFeeTest(string start, string end, int expect)
        {
            var parkingFee = new Solution().CalcParkingFee(DateTime.Parse(start), DateTime.Parse(end));
            Assert.AreEqual(expect, parkingFee.TotalFee);
        }

        [TestMethod("start < end")]
        public void CalcParkingFeeExceptionTest()
        {
            var start = DateTime.Parse("2002/5/1 23:50:00");
            var end = DateTime.Parse("2002/5/1 00:10:59");

            Assert.ThrowsException<ArgumentException>(() => new Solution().CalcParkingFee(start, end));
        }
    }
}