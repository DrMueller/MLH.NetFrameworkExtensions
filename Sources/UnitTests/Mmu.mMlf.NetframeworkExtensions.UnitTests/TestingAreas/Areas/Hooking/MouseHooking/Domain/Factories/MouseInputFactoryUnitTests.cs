using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.MouseHooking.Domain.Factories
{
    [TestFixture]
    public class MouseInputFactoryUnitTests
    {
        private MouseInputFactory _sut;

        [Test]
        public void Mapping_ReturnesMappedInput()
        {
            // Arrange
            var nativeMouseInput = new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseUp);

            // Act
            var actualMouseInput = _sut.CreateFromNativeMouseInput(nativeMouseInput);

            // Assert
            Assert.AreEqual(MouseInputKey.Left, actualMouseInput.InputKey);
            Assert.AreEqual(MouseInputDirection.MouseUp, actualMouseInput.Direction);
        }

        [SetUp]
        public void SetUp()
        {
            _sut = new MouseInputFactory();
        }
    }
}