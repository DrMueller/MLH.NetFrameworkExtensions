using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class ModifierConfiguration
    {
        public Option<bool> AltMustBePressed { get; }
        public Option<bool> CtrlMustBepressed { get; }
        public Option<bool> ShiftMustBePressed { get; }

        public ModifierConfiguration(Option<bool> ctrlMustBepressed, Option<bool> shiftMustBePressed, Option<bool> altMustBePressed)
        {
            Guard.ObjectNotNull(() => ctrlMustBepressed);
            Guard.ObjectNotNull(() => shiftMustBePressed);
            Guard.ObjectNotNull(() => altMustBePressed);

            CtrlMustBepressed = ctrlMustBepressed;
            ShiftMustBePressed = shiftMustBePressed;
            AltMustBePressed = altMustBePressed;
        }

        internal bool CheckIfApplicable(KeyboardInputModifiers inputModifiers)
        {
            return CtrlMustBepressed == inputModifiers.IsCtrlPressed &&
                ShiftMustBePressed == inputModifiers.IsShiftPressed &&
                AltMustBePressed == inputModifiers.IsAltPressed;
        }

        public static ModifierConfiguration CreateNotApplibable()
        {
            return new ModifierConfiguration(
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true));
        }
    }
}