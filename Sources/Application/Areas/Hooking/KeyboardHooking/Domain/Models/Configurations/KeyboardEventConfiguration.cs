using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class KeyboardEventConfiguration : IEventConfiguration
    {
        public KeyboardInputKeyConfiguration InputKeyConfiguration { get; }
        public LockConfiguration LockConfiguration { get; }
        public ModifierConfiguration ModifierConfiguration { get; }

        public KeyboardEventConfiguration(KeyboardInputKeyConfiguration inputKeyConfiguration, ModifierConfiguration modifierConfiguration, LockConfiguration lockConfiguration)
        {
            Guard.ObjectNotNull(() => inputKeyConfiguration);
            Guard.ObjectNotNull(() => modifierConfiguration);
            Guard.ObjectNotNull(() => lockConfiguration);

            InputKeyConfiguration = inputKeyConfiguration;
            ModifierConfiguration = modifierConfiguration;
            LockConfiguration = lockConfiguration;
        }

        public static KeyboardEventConfiguration CreateForAllEvents()
        {
            return new KeyboardEventConfiguration(new KeyboardInputKeyConfiguration(KeyboardInputKey.AllKeys.ToArray()),
                ModifierConfiguration.CreateNotApplibable(),
                LockConfiguration.CreateNotApplicable());
        }

        public bool CheckIfApplicable(KeyboardInput input)
        {
            return InputKeyConfiguration.CheckIfApplicable(input.InputKey) &&
                ModifierConfiguration.CheckIfApplicable(input.Modifiers) &&
                LockConfiguration.CheckIfApplicable(input.Locks);
        }
    }
}