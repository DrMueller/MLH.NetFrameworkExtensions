using System.Linq;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    internal class KeyboardInputKeyMappingServant : IKeyboardInputKeyMappingServant
    {
        public KeyboardInputKey MapFromNativeKey(Keys key)
        {
            return KeyboardInputKey.AllKeys.Single(f => f.NativeRepresentation == key.ToString());
        }
    }
}