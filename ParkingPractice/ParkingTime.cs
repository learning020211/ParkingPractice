using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPractice
{
    public struct ParkingTime : IComparable<DateTime>
    {
        public DateTime Value { get; private set; }
        public ParkingTime(DateTime parkingTime)
        {
            Value = parkingTime.SkipToMinute();
        }

        public int CompareTo(DateTime other) => Value.CompareTo(other);

        #region 運算子多載
        public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(ParkingTime parkingTime1, ParkingTime parkingTime2) => parkingTime1.Value == parkingTime2.Value;
        public static bool operator !=(ParkingTime parkingTime1, ParkingTime parkingTime2) => !(parkingTime1 == parkingTime2);

        public static bool operator >(ParkingTime parkingTime1, ParkingTime parkingTime2) => parkingTime1.Value > parkingTime2.Value;
        public static bool operator <(ParkingTime parkingTime1, ParkingTime parkingTime2) => parkingTime1.Value < parkingTime2.Value;

        public static bool operator >=(ParkingTime parkingTime1, ParkingTime parkingTime2) => parkingTime1 > parkingTime2 || parkingTime1 == parkingTime2;
        public static bool operator <=(ParkingTime parkingTime1, ParkingTime parkingTime2) => parkingTime1 < parkingTime2 || parkingTime1 == parkingTime2;
        #endregion

        #region 隱式轉型
        public static implicit operator DateTime(ParkingTime source) => source.Value;
        public static implicit operator ParkingTime(DateTime source) => new ParkingTime(source);
        #endregion
    }
}
