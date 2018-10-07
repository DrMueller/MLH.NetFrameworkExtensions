using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;
using StructureMap;

namespace Mmu.Mlh.NetFrameworkExtensions.TestConsole
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(scanner =>
                 {
                     scanner.AssemblyContainingType<TestConsoleRegistry>();
                     scanner.AddAllTypesOf<IKeyboardInputReceiver>();
                     scanner.AddAllTypesOf<IMouseInputReceiver>();
                     scanner.WithDefaultConventions();
                 });
        }
    }
}
