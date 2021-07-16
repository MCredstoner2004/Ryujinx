using Ryujinx.HLE.HOS.Services.Hid.Types.Common;
using Ryujinx.Common.Memory;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    struct NpadInternalState
    {
        public NpadStyleTag StyleSet;
        public NpadJoyAssignmentMode JoyAssignmentMode;
        public NpadFullKeyColorState FullKeyColor;
        public NpadJoyColorState JoyColor;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> FullKey;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> Handheld;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> JoyDual;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> JoyLeft;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> JoyRight;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> Palma;
        public RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>> SystemExt;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> FullKeySixAxisSensor;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> HandheldSixAxisSensor;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> JoyDualSixAxisSensor;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> JoyDualRightSixAxisSensor;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> JoyLeftSixAxisSensor;
        public RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>> JoyRightSixAxisSensor;
        public DeviceType DeviceType;
        private uint _reserved1;
        public NpadSystemProperties SystemProperties;
        public NpadSystemButtonProperties SystemButtonProperties;
        public NpadBatteryLevel BatteryLevelJoyDual;
        public NpadBatteryLevel BatteryLevelJoyLeft;
        public NpadBatteryLevel BatteryLevelJoyRight;
        public uint AppletFooterUiAttributes;
        public AppletFooterUiType AppletFooterUiType;
        private unsafe fixed byte _reserved2[0x7B];
        public RingLifo<NpadGcTriggerState, Array17<AtomicStorage<NpadGcTriggerState>>> GcTrigger;
        public NpadLarkType LarkTypeLeftAndMain;
        public NpadLarkType LarkTypeRight;
        public NpadLuciaType LuciaType;
        public uint Unknown43EC;

        public static NpadInternalState Create()
        {
            return new NpadInternalState
            {
                FullKey = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                Handheld = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                JoyDual = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                JoyLeft = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                JoyRight = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                Palma = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                SystemExt = RingLifo<NpadCommonState, Array17<AtomicStorage<NpadCommonState>>>.Create(),
                FullKeySixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                HandheldSixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                JoyDualSixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                JoyDualRightSixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                JoyLeftSixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                JoyRightSixAxisSensor = RingLifo<SixAxisSensorState, Array17<AtomicStorage<SixAxisSensorState>>>.Create(),
                GcTrigger = RingLifo<NpadGcTriggerState, Array17<AtomicStorage<NpadGcTriggerState>>> .Create(),
            };
        }
    }
}
