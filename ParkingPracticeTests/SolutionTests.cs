using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingPractice.Calculators;
using System;
using System.Linq;

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
        [DataRow("2022/5/1 09:00:00", "2022/5/1 09:10:59", 0, 1, DisplayName = "同一天")]
        [DataRow("2022/5/1 09:00:00", "2022/5/1 09:11:59", 7, 1, DisplayName = "同一天")]
        [DataRow("2022/5/1 09:00:00", "2022/5/1 10:00:59", 10, 1, DisplayName = "同一天")]

        [DataRow("2022/5/1 23:49:00", "2022/5/2 00:10:59", 0, 2, DisplayName = "跨一天,免費")]

        [DataRow("2022/5/1 23:48:00", "2022/5/2 00:00:00", 7, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/1 23:48:00", "2022/5/2 00:11:59", 14, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/1 00:00:00", "2022/5/2 00:11:59", 57, 2, DisplayName = "跨一天,收費")]

        [DataRow("2022/5/1 23:49:00", "2022/5/3 00:11:59", 57, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/1 22:59:00", "2022/5/3 00:11:59", 67, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/1 00:00:00", "2022/5/3 00:11:59", 107, 3, DisplayName = "跨2天,收費")]
        public void CalcParkingFeeTest(string start, string end, int fee, int days)
        {
            var parkingFee = new Solution().CalcParkingFee(DateTime.Parse(start), DateTime.Parse(end));
            Assert.IsTrue(fee == parkingFee.TotalFee && days == parkingFee.Items.Count());
        }

        [TestMethod("start < end")]
        public void CalcParkingFeeExceptionTest()
        {
            var start = DateTime.Parse("2002/5/1 23:50:00");
            var end = DateTime.Parse("2002/5/1 00:10:59");

            Assert.ThrowsException<ArgumentException>(() => new Solution().CalcParkingFee(start, end));
        }

        [TestMethod()]
        [DataRow("2022/5/1 09:00:00", "2022/5/1 09:10:59", 0, 1, DisplayName = "同一天")]
        [DataRow("2022/5/1 09:00:00", "2022/5/1 09:11:59", 7, 1, DisplayName = "同一天")]
        [DataRow("2022/5/1 09:00:00", "2022/5/1 10:00:59", 10, 1, DisplayName = "同一天")]

        [DataRow("2022/5/1 23:49:00", "2022/5/2 00:10:59", 0, 2, DisplayName = "跨一天,免費")]

        [DataRow("2022/5/1 23:48:00", "2022/5/2 00:00:00", 7, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/1 23:48:00", "2022/5/2 00:11:59", 14, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/1 00:00:00", "2022/5/2 00:11:59", 57, 2, DisplayName = "跨一天,收費")]

        [DataRow("2022/5/1 23:49:00", "2022/5/3 00:11:59", 57, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/1 22:59:00", "2022/5/3 00:11:59", 67, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/1 00:00:00", "2022/5/3 00:11:59", 107, 3, DisplayName = "跨2天,收費")]
        public void CalcParkingFeeTestA(string start, string end, int fee, int days)
        {
            var rate = new ParkingRateA();
            var parkingFee = new Solution().CalcParkingFee(rate, DateTime.Parse(start), DateTime.Parse(end));
            Assert.IsTrue(fee == parkingFee.TotalFee && days == parkingFee.Items.Count());
        }

        [TestMethod]
        //平日
        [DataRow("2022/5/2 09:00:00", "2022/5/2 09:10:59", 0, 1, DisplayName = "同一天")]
        [DataRow("2022/5/2 09:00:00", "2022/5/2 09:11:59", 7, 1, DisplayName = "同一天")]
        [DataRow("2022/5/2 09:00:00", "2022/5/2 10:00:59", 10, 1, DisplayName = "同一天")]
        [DataRow("2022/5/2 23:49:00", "2022/5/3 00:10:59", 0, 2, DisplayName = "跨一天,免費")]
        [DataRow("2022/5/2 23:48:00", "2022/5/3 00:00:00", 7, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/2 23:48:00", "2022/5/3 00:11:59", 14, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/2 00:00:00", "2022/5/3 00:11:59", 57, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/2 23:49:00", "2022/5/4 00:11:59", 57, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/2 22:59:00", "2022/5/4 00:11:59", 67, 3, DisplayName = "跨2天,收費")]
        [DataRow("2022/5/2 00:00:00", "2022/5/4 00:11:59", 107, 3, DisplayName = "跨2天,收費")]

        //假日
        [DataRow("2022/5/7 09:00:00", "2022/5/7 09:01:59", 15, 1, DisplayName = "1分鐘,15元")]
        [DataRow("2022/5/7 09:00:00", "2022/5/7 10:00:59", 15, 1, DisplayName = "60分鐘,15元")]
        [DataRow("2022/5/7 09:00:00", "2022/5/7 09:00:59", 0, 1, DisplayName = "0分, 0元")]
        [DataRow("2022/5/7 09:00:00", "2022/5/7 10:01:59", 30, 1, DisplayName = "61分, 30元")]

        [DataRow("2022/5/7 23:58:00", "2022/5/8 00:01:00", 30, 2, DisplayName = "跨一天,收費")]
        [DataRow("2022/5/7 00:00:00", "2022/5/8 00:11:59", 265, 2, DisplayName = "250 + 15")]
        public void CalcParkingFeeTestB(string start, string end, int fee, int days)
        {
            var rate = new ParkingRateB();
            var parkingFee = new Solution().CalcParkingFee(rate, DateTime.Parse(start), DateTime.Parse(end));
            Assert.IsTrue(fee == parkingFee.TotalFee && days == parkingFee.Items.Count());

        }

        [TestMethod]
        //平日
        [DataRow("2022/5/2 09:00:00", "2022/5/2 10:00:59", 20, 1, DisplayName = "同一天, 第一小時為20元")]
        [DataRow("2022/5/2 09:00:00", "2022/5/2 10:01:00", 50, 1, DisplayName = "同一天, 61分,第一小時20,第二小時起,每小時30")]
        [DataRow("2022/5/2 09:00:00", "2022/5/2 11:01:00", 80, 1, DisplayName = "2小又1分,第一小時20,第二小時起,每小時30")]
        [DataRow("2022/5/2 09:00:00", "2022/5/2 12:01:00", 110, 1, DisplayName = "3小又1分,第一小時20,第二小時起,每小時30")]

        [DataRow("2022/5/2 23:48:00", "2022/5/3 00:00:00", 20, 2, DisplayName = "跨一天,20 + 0")]
        [DataRow("2022/5/2 23:48:00", "2022/5/3 00:11:59", 40, 2, DisplayName = "跨一天,20 + 20")]
        [DataRow("2022/5/2 00:00:00", "2022/5/3 01:01:00", 350, 2, DisplayName = "跨一天,第二天1小時又1分, 300 + 50")]

        [DataRow("2022/5/2 23:49:00", "2022/5/4 00:11:59", 340, 3, DisplayName = "跨2天,20 + 300 + 20")]

        //假日
        [DataRow("2022/5/7 00:00:00", "2022/5/7 23:59:59", 0, 1, DisplayName = "1分鐘,假日免費")]
        [DataRow("2022/5/7 00:00:00", "2022/5/8 23:59:59", 0, 2, DisplayName = "跨一天,假日免費")]
        public void CalcParkingFeeTestC(string start, string end, int fee, int days)
        {
            var rate = new ParkingRateC();
            var parkingFee = new Solution().CalcParkingFee(rate, DateTime.Parse(start), DateTime.Parse(end));
            Assert.IsTrue(fee == parkingFee.TotalFee && days == parkingFee.Items.Count());

        }

        [TestMethod()]
        [DataRow("2022/5/7 00:00:00", "2022/5/7 23:59:59", 240, DisplayName = "停一天")]
        [DataRow("2022/5/7 00:00:00", "2022/5/7 00:01:00", 5, DisplayName = "停一分鐘")]
        public void CalcPeriodFeeTestA(string start, string end, int fee)
        {
            //費率A : 00:00 ~ 24:00 , 每 30 分鐘 5 元, 無上限
            var rate = new PeriodRate()
            {
                StartTime = TimeSpan.Zero,
                EndTime = TimeSpan.FromDays(1),
                UnitTime = TimeSpan.FromMinutes(30),
                Fee = 5,
            };

            var parkingFee = new Solution().CalcPeriodFee(rate, DateTime.Parse(start), DateTime.Parse(end));

            Assert.AreEqual(parkingFee.Sum(f => f.Fee) , fee);
        }
    }
}