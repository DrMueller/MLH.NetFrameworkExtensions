using System;
using System.Diagnostics;
using System.Text;
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
            var sb = new StringBuilder();
            sb.AppendLine($"Key: {keyboardInput.InputKey}");
            sb.AppendLine($"Direction: {keyboardInput.Direction}");
            sb.AppendLine($"Modifier Shift: {keyboardInput.ModifierOptions.IsShiftPressed}");
            sb.AppendLine($"Modifier Ctrl: {keyboardInput.ModifierOptions.IsCtrlPressed}");
            sb.AppendLine($"Modifier Alt: {keyboardInput.ModifierOptions.IsAltPressed}");
            sb.AppendLine($"Lock Caps: {keyboardInput.LockOptions.IsCapsLockActive}");
            sb.AppendLine($"Lock Num: {keyboardInput.LockOptions.IsNumLockActive}");
            sb.AppendLine($"Lock Scroll: {keyboardInput.LockOptions.IsScrollLockActive}");

            Debug.WriteLine(sb.ToString());
        }

        private static void OnMouseInput(MouseInput mouseInput)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Key: {mouseInput.InputKey}");
            sb.AppendLine($"Direction: {mouseInput.Direction}");

            Debug.WriteLine(sb.ToString());
        }
    }
}