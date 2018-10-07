using System;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class KeyboardInputMap
    {
        private readonly KeyboardEventConfiguration _configuration;
        private readonly Func<KeyboardInput, Task> _onKeyboardInput;

        public KeyboardInputMap(KeyboardEventConfiguration configuration, Func<KeyboardInput, Task> onKeyboardInput)
        {
            _configuration = configuration;
            _onKeyboardInput = onKeyboardInput;
        }

        public async Task HandleAsync(KeyboardInput keyboardInput)
        {
            if (_configuration.CheckIfApplicable(keyboardInput))
            {
                await _onKeyboardInput(keyboardInput);
            }
        }
    }
}