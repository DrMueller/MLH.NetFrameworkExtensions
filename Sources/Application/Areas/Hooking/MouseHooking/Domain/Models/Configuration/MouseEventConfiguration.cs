using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configuration
{
    public class MouseEventConfiguration
    {
        public Option<MouseInputDirection> InputDirection { get; }
        public Option<MouseInputKey> InputKey { get; }

        public MouseEventConfiguration(Option<MouseInputKey> inputKey, Option<MouseInputDirection> inputDirection)
        {
            InputKey = inputKey;
            InputDirection = inputDirection;
        }

        internal bool CheckIfApplicable(MouseInput mouseInput)
        {
            return InputKey == mouseInput.InputKey && InputDirection == mouseInput.Direction;
        }

        public static MouseEventConfiguration CreateForAllEvents()
        {
            return new MouseEventConfiguration(
                Option.CreateNotApplicable<MouseInputKey>(true),
                Option.CreateNotApplicable<MouseInputDirection>(true));
        }
    }
}