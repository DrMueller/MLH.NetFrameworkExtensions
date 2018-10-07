using System;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configuration;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole.Receivers
{
    public class TestMouseInputReceiver : IMouseInputReceiver
    {
        private static Lazy<MouseEventConfiguration> _config = new Lazy<MouseEventConfiguration>(MouseEventConfiguration.CreateForAllEvents);
        public MouseEventConfiguration Configuration => _config.Value;

        public Task ReceiveAsync(MouseInput input)
        {
            Console.WriteLine(input.CreateOverview());
            return Task.CompletedTask;
        }
    }
}