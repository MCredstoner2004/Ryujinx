using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Hid.Types.Common;
 
namespace Ryujinx.HLE.HOS.Services.Hid.Types.TransferMemory.SevenSixAxis
{
    struct SevenSixAxisSensorState : ISampledData
    {
        public ulong _unused;
        public ulong TimeStamp;
        public ulong SamplingNumber;
        public ulong ResetsCount;
        public HidVector Acceleration;
        public HidVector AngularVelocity;
        public HidQuaternion Orientation;
        ulong ISampledData.SamplingNumber => SamplingNumber;
    }
}
