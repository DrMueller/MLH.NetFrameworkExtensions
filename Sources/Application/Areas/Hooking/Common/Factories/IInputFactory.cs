using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Factories
{
    public interface IInputFactory<TInput, TNativeInput>
        where TInput : IInput
        where TNativeInput : INativeInput
    {
        TInput Create(TNativeInput nativeInput);
    }
}