using System;
using System.Diagnostics;
using System.Windows.Forms;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            ContainerInitializationService.CreateInitializedContainer(new AssemblyParameters(typeof(Program).Assembly, "Mmu.Mlh"));
            var keyboardHookService = ProvisioningServiceSingleton.Instance.GetService<IKeyboardHookService>();
            var mouseHookService = ProvisioningServiceSingleton.Instance.GetService<IMouseHookService>();

            keyboardHookService.HookKeyboard(OnKeyboardInput);
            mouseHookService.HookMouse(OnMouseInput);

            Application.Run();
        }

        private static void OnKeyboardInput(KeyboardInput keyboardInput)
        {
            Debug.WriteLine(keyboardInput.CreateOverview());
        }

        private static void OnMouseInput(MouseInput mouseInput)
        {
            Debug.WriteLine(mouseInput.CreateOverview());
        }
    }
}