using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.SevenSixAxis
{
     [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    struct SevenSixAxisSensor
    {
        [FieldOffset(0)]
        public ulong SamplingNumber;
        [FieldOffset(8)]
        public byte AtRest;
        [FieldOffset(12)]
        public float SensorFusionError;
        [FieldOffset(16)]
        public HidVector GyroBias;
    }
}
