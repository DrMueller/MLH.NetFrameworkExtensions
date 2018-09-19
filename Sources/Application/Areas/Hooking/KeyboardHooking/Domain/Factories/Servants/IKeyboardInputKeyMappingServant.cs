using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants
{
    internal interface IKeyboardInputKeyMappingServant
    {
        KeyboardInputKey MapFromNativeKey(Keys key);
    }
}