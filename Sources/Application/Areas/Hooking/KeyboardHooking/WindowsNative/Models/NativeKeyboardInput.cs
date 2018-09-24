using System.Text;
using System.Windows.Forms;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models
{
    public class NativeKeyboardInput
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