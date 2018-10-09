using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;
using StructureMap;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestConsoleRegistry>();
                    scanner.AddAllTypesOf<IKeyboardInputReceiver>();
                    scanner.AddAllTypesOf<IMouseInputReceiver>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}