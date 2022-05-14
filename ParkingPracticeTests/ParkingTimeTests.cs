using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice.Tests
{
    [TestClass()]
    public class ParkingTimeTests
    {
        [TestMethod()]
        [TestCategory("精確到分")]
        [DataRow("2020/1/2 13:00:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:00:59.999", "2020/1/2 13:00:00")]
        public void Value_只精確到分鐘(string source, string expectedValue)
        {
            var dtSource = Convert.ToDateTime(source);
            var expected = Convert.ToDateTime(expectedValue);

            DateTime actual = new ParkingTime(dtSource).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("支援與DateTime比大小")]
        [DataRow("2020/1/2 13:00:59.999", "2020/1/2 13:00:00")]
        public void Test_支援與DateTime比大小_相等_Returns0(string source, string otherValue)
        {
            var dtSource = Convert.ToDateTime(source);
            var other = Convert.ToDateTime(otherValue);

            int actual = new ParkingTime(dtSource).CompareTo(other);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        [TestCategory("支援與DateTime比大小")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:00:00")]
        public void Test_支援與DateTime比大小_大於_Returns正數(string source, string otherValue)
        {
            var dtSource = Convert.ToDateTime(source);
            var other = Convert.ToDateTime(otherValue);

            int actual = new ParkingTime(dtSource).CompareTo(other);

            Assert.IsTrue(actual > 0);
        }

        [TestMethod()]
        [TestCategory("支援與DateTime比大小")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:02:00")]
        public void Test_支援與DateTime比大小_大於_Returns負數(string source, string otherValue)
        {
            var dtSource = Convert.ToDateTime(source);
            var other = Convert.ToDateTime(otherValue);

            int actual = new ParkingTime(dtSource).CompareTo(other);

            Assert.IsTrue(actual < 0);
        }

        [TestMethod()]
        [TestCategory("隱式轉型")]
        public void 隱式轉型_DateTime轉ParkingTime()
        {
            DateTime source = new DateTime(1980, 2, 5, 13, 0, 15); // 1980/2/5 13:00:15
            ParkingTime actual = source; // 1980/2/5 13:00:00 只精確到分
            DateTime expected = new DateTime(1980, 2, 5, 13, 0, 0); // 1980/2/5 13:00:00

            Assert.AreEqual(expected, actual.Value);
        }

        [TestMethod()]
        [TestCategory("隱式轉型")]
        public void 隱式轉型_ParkingTime轉DateTime()
        {
            DateTime source = new DateTime(1980, 2, 5, 13, 0, 15); // 1980/2/5 13:00:15
            ParkingTime actual = source; // 1980/2/5 13:00:00 只精確到分

            DateTime expected = new DateTime(1980, 2, 5, 13, 0, 0); // 1980/2/5 13:00:00

            Assert.AreEqual(expected, (DateTime)actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:00:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:00:59.999", "2020/1/2 13:00:00")]
        public void 運算子多載_等於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource == expected;

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:00:00")]
        public void 運算子多載_不等於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource != expected;

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:00:00")]
        public void 運算子多載_大於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource > expected;

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:00:00", "2020/1/2 13:00:00")]
        [DataRow("2020/1/2 13:00:59.999", "2020/1/2 13:00:00")]
        public void 運算子多載_大於或等於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource >= expected;

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:02:00")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:02:00")]
        public void 運算子多載_小於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource < expected;

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [TestCategory("運算子多載")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:02:00")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:02:00")]
        [DataRow("2020/1/2 13:01:00", "2020/1/2 13:01:59")]
        [DataRow("2020/1/2 13:01:59.999", "2020/1/2 13:01:30")]
        public void 運算子多載_小於或等於(string source, string expectedValue)
        {
            var dtSource = (ParkingTime)Convert.ToDateTime(source);
            var expected = (ParkingTime)Convert.ToDateTime(expectedValue);

            bool actual = dtSource <= expected;

            Assert.IsTrue(actual);
        }
    }
}