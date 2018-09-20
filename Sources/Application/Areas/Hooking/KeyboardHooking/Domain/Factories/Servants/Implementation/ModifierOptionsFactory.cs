using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Imports;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class ModifierOptionsFactory : IModifierOptionsFactory
    {
        public ModifierOptions Create()
        {
            var isShiftPressed = CheckIfActive(NativeMethods.GetKeyState(Keys.ShiftKey));
            var isCtrlpressed = CheckIfActive(NativeMethods.GetKeyState(Keys.ControlKey));
            var isAltpressed = CheckIfActive(NativeMethods.GetKeyState(Keys.Menu));

            return new ModifierOptions(
                isCtrlpressed,
                isAltpressed,
                isShiftPressed);
        }

        private static bool CheckIfActive(short state)
        {
            return state > 1 || state < -1;
        }
    }
}