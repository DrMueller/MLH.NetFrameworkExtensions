using System;
using System.Windows.Forms;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var provisioningService =
                ContainerInitializationService.CreateInitializedContainer(new AssemblyParameters(typeof(Program).Assembly, "Mmu.Mlh"))
                    .GetInstance<IProvisioningService>();

            var keyboardHookService = provisioningService.GetService<IKeyboardHookService>();
            var mouseHookService = provisioningService.GetService<IMouseHookService>();

            mouseHookService.HookMouse();
            keyboardHookService.HookKeyboard();

            Application.Run();
        }
    }
}