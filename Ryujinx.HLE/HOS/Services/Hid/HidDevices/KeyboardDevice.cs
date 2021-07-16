using Ryujinx.HLE.HOS.Services.Hid.Types.Common;
using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Keyboard;
using System;

namespace Ryujinx.HLE.HOS.Services.Hid
{
    public class KeyboardDevice : BaseDevice
    {
        public KeyboardDevice(Switch device, bool active) : base(device, active) { }

        public unsafe void Update(KeyboardInput keyState)
        {
            ref RingLifo<KeyboardState, Array17<AtomicStorage<KeyboardState>>> lifo = ref _device.Hid.SharedMemory.Keyboard;

            if (!Active)
            {
                lifo.Clear();

                return;
            }

            ref KeyboardState previousEntry = ref lifo.GetCurrentEntryRef();

            KeyboardState newState = new KeyboardState
            {
                SamplingNumber = previousEntry.SamplingNumber + 1,
            };

            keyState.Keys.AsSpan().CopyTo(newState.Keys.RawData.ToSpan());
            newState.Modifiers = (KeyboardModifier)keyState.Modifier;

            lifo.Write(ref newState);
        }
    }
}
