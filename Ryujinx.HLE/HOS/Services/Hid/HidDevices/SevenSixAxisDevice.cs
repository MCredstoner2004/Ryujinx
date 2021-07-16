using Ryujinx.HLE.HOS.Kernel.Memory;
using System.Collections.Generic;
using Ryujinx.HLE.HOS.Services.Hid.Types.Common;
using Ryujinx.HLE.HOS.Services.Hid.Types;
using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Hid.Types.TransferMemory.SevenSixAxis;
using System;

namespace Ryujinx.HLE.HOS.Services.Hid {
    public class SevenSixAxisDevice : BaseDevice

    {
        public SevenSixAxisDevice(Switch device, bool active) : base(device, active) {
            _device.Hid.SharedMemory.SevenSixAxis.SamplingNumber = 0;
            _device.Hid.SharedMemory.SevenSixAxis.GyroBias = new HidVector() //should depend on the sensor, and should be update when the sensor is at rest
            {
                X = 0.05f,
                Y = 0.05f,
                Z = 0.05f
            };
            _device.Hid.SharedMemory.SevenSixAxis.SensorFusionError = 0.0f;
        }
        internal ulong           InitializerResourceAppletUserID = 0;
        internal List<ulong>     StartersResourceAppletUserIDs = new List<ulong>();
        internal ulong           ReferenceTimestamp = 0;
        internal ulong           ResetsCount = 0;
        internal float           SensorFusionStrength = 1.0f;
        internal KTransferMemory TransferMemory = null;
        internal bool ReferenceTimestampSet = false;

        public void Update(SevenSixAxisInput state) {
            if (StartersResourceAppletUserIDs.Count > 0) {
                if(!ReferenceTimestampSet) {
                    ReferenceTimestamp = state.TimeStamp;
                    ReferenceTimestampSet = true;
                }
            }
            if (StartersResourceAppletUserIDs.Contains(InitializerResourceAppletUserID) && TransferMemory != null && Active){
                ref RingLifo<SevenSixAxisSensorState, Array33<AtomicStorage<SevenSixAxisSensorState>>> lifo = ref TransferMemory.Creator.CpuMemory.GetRef<RingLifo<SevenSixAxisSensorState, Array33<AtomicStorage<SevenSixAxisSensorState>>>>(TransferMemory.Address);
                SevenSixAxisSensorState new_state = new SevenSixAxisSensorState();
                _device.Hid.SharedMemory.SevenSixAxis.SamplingNumber++;
                _device.Hid.SharedMemory.SevenSixAxis.AtRest = (byte)((state.Gyroscope.Length() < 0.02 && Math.Abs(state.Accelerometer.Length() - 1) < 0.02)? 1 : 0); //guessed values
                new_state.TimeStamp = state.TimeStamp - ReferenceTimestamp;
                new_state.ResetsCount = ResetsCount;
                new_state.SamplingNumber = _device.Hid.SharedMemory.SevenSixAxis.SamplingNumber;
                new_state.Acceleration = new HidVector()
                {
                    X = state.Accelerometer.X,
                    Y = state.Accelerometer.Y,
                    Z = state.Accelerometer.Z
                };
                new_state.AngularVelocity = new HidVector()
                {
                    X = state.Gyroscope.X,
                    Y = -state.Gyroscope.Y,
                    Z = state.Gyroscope.Z
                };
                new_state.Orientation = new HidQuaternion()
                {
                    X = state.Orientation.X,
                    Y = state.Orientation.Y,
                    Z = state.Orientation.Z,
                    W = state.Orientation.W
                };
                lifo.Write(ref new_state);
            }
        }
    }
}

