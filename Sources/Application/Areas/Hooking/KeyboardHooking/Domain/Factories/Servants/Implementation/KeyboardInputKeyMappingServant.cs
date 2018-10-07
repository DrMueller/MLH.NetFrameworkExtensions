using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardInputKeyMappingServant : IKeyboardInputKeyMappingServant
    {
        public KeyboardInputKey MapFromNativeKey(Keys key)
        {
            return KeyboardInputKey.AllKeys.Single(f => f.NativeRepresentation == key.ToString());
        }
    }
}