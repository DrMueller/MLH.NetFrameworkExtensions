namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class KeyboardInput
    {
        public KeyboardInputDirection Direction { get; }
        public KeyboardInputKey InputKey { get; }
        public LockOptions LockOptions { get; }
        public ModifierOptions ModifierOptions { get; }

        public KeyboardInput(
            KeyboardInputDirection direction,
            KeyboardInputKey inputKey,
            LockOptions lockOptions,
            ModifierOptions modifierOptions)
        {
            Direction = direction;
            InputKey = inputKey;
            LockOptions = lockOptions;
            ModifierOptions = modifierOptions;
        }
    }
}