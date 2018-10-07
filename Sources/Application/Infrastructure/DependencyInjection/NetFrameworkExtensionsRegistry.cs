using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.DependencyInjection
{
    public class NetFrameworkExtensionsRegistry : Registry
    {
        public NetFrameworkExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<NetFrameworkExtensionsRegistry>();
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.AddAllTypesOf<IKeyboardInputReceiver>();
                    scanner.AddAllTypesOf<IMouseInputReceiver>();
                    scanner.WithDefaultConventions();
                });

            // Hooking - Keyboard
            For<INativeKeyboardHookService>().Use<NativeKeyboardHookService>().Transient();
            For<IKeyboardHookService>().Use<KeyboardHookService>().Transient();
            For<IKeyboardInputFactory>().Use<KeyboardInputFactory>().Singleton();
            For<IKeyboardInputKeyMappingServant>().Use<KeyboardInputKeyMappingServant>();
            For<IKeyboardInputModifiersFactory>().Use<KeyboardInputModifiersFactory>();
            For<IKeyboardInputLocksFactory>().Use<KeyboardInputLocksFactory>();

            // Hooking - Mouse
            For<INativeMouseHookService>().Use<NativeMouseHookService>().Transient();
            For<IMouseHookService>().Use<MouseHookService>().Transient();
            For<IMouseInputFactory>().Use<MouseInputFactory>().Singleton();

            // Infrastructure - WindowsNative
            For<IHookService>().Use<HookService>().AlwaysUnique();
        }
    }
}