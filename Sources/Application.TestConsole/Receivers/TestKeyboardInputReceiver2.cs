using System;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole.Receivers
{
    public class TestKeyboardInputReceiver2 : IKeyboardInputReceiver
    {
        private static Lazy<KeyboardEventConfiguration> _config = new Lazy<KeyboardEventConfiguration>(KeyboardEventConfiguration.CreateForAllEvents);
        public KeyboardEventConfiguration Configuration => _config.Value;

        public Task<bool> ReceiveAsync(KeyboardInput input)
        {
            Console.WriteLine(input.CreateOverview());
            return Task.FromResult(true);
        }
    }
}