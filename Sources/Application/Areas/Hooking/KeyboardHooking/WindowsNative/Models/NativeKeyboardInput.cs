using System.Text;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models
{
    public class NativeKeyboardInput : INativeInput
    {
        public NativeKeyboardInputDirection Direction { get; }
        public Keys Key { get; }

        public NativeKeyboardInput(Keys key, NativeKeyboardInputDirection direction)
        {
            Key = key;
            Direction = direction;
        }
    }
}