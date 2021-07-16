using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Hid.Types.Common;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.DebugPad;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Keyboard;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Mouse;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.TouchScreen;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.SevenSixAxis;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory
{
    /// <summary>
    /// Represent the shared memory shared between applications for input.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40000)]
    struct SharedMemory
    {
        /// <summary>
        /// Debug controller.
        /// </summary>
        [FieldOffset(0)]
        public RingLifo<DebugPadState, Array17<AtomicStorage<DebugPadState>>> DebugPad;

        /// <summary>
        /// Touchscreen.
        /// </summary>
        [FieldOffset(0x400)]
        public RingLifo<TouchScreenState, Array17<AtomicStorage<TouchScreenState>>> TouchScreen;

        /// <summary>
        /// Mouse.
        /// </summary>
        [FieldOffset(0x3400)]
        public RingLifo<MouseState, Array17<AtomicStorage<MouseState>>> Mouse;

        /// <summary>
        /// Keyboard.
        /// </summary>
        [FieldOffset(0x3800)]
        public RingLifo<KeyboardState, Array17<AtomicStorage<KeyboardState>>> Keyboard;

        /// <summary>
        /// Nintendo Pads.
        /// </summary>
        [FieldOffset(0x9A00)]
        public Array10<NpadState> Npads;

        /// <summary>
        /// SevenSixAxis Sensor.
        /// </summary>
        [FieldOffset(0x3C200)]
        public SevenSixAxisSensor SevenSixAxis;

        public static SharedMemory Create()
        {
            SharedMemory result = new SharedMemory
            {
                DebugPad = RingLifo<DebugPadState, Array17<AtomicStorage<DebugPadState>>>.Create(),
                TouchScreen = RingLifo<TouchScreenState, Array17<AtomicStorage<TouchScreenState>>>.Create(),
                Mouse = RingLifo<MouseState, Array17<AtomicStorage<MouseState>>>.Create(),
                Keyboard = RingLifo<KeyboardState, Array17<AtomicStorage<KeyboardState>>>.Create(),
            };

            for (int i = 0; i < result.Npads.Length; i++)
            {
                result.Npads[i] = NpadState.Create();
            }

            return result;
        }
    }
}
