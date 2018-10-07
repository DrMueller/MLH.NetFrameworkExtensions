using System.Text;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs
{
    public class MouseInput : IInput
    {
        public MouseInputDirection Direction { get; }
        public MouseInputKey InputKey { get; }

        public MouseInput(MouseInputKey inputKey, MouseInputDirection direction)
        {
            InputKey = inputKey;
            Direction = direction;
        }

        public string CreateOverview()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Key: {InputKey}");
            sb.AppendLine($"Direction: {Direction}");

            return sb.ToString();
        }
    }
}