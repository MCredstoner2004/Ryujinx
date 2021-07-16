using System.Numerics;

namespace Ryujinx.HLE.HOS.Services.Hid
{
    public struct SevenSixAxisInput
    {
        public Vector3    Accelerometer;
        public Vector3    Gyroscope;
        public Quaternion Orientation;
        public ulong      TimeStamp;
    }
}