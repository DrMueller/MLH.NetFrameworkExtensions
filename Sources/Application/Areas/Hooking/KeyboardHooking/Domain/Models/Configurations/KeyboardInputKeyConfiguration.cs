using System.Linq;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class KeyboardInputKeyConfiguration
    {
        private readonly KeyboardInputKey[] _keys;

        public KeyboardInputKeyConfiguration(params KeyboardInputKey[] keys)
        {
            _keys = keys;
        }

        internal bool CheckIfApplicable(KeyboardInputKey inputKey)
        {
            return _keys.Contains(inputKey);
        }
    }
}