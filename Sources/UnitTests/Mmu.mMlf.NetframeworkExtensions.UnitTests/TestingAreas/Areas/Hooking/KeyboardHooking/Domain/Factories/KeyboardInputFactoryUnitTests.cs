using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.KeyboardHooking.Domain.Factories
{
    [TestFixture]
    public class KeyboardInputFactoryUnitTests
    {
        private Mock<IKeyboardInputKeyMappingServant> _inputKeyMappingServantMock;
        private Mock<IKeyboardInputLocksFactory> _lockOptionsFactoryMock;
        private Mock<IKeyboardInputModifiersFactory> _modifierOptionsFactoryMock;
        private KeyboardInputFactory _sut;

        [Test]
        public void Mapping_CallsInputKeyMappingServantOnceWithPassedNativeKey()
        {
            // Arrange
            const Keys NativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(NativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputLocks(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputModifiers(true, true, true));

            // Act
            _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            _inputKeyMappingServantMock.Verify(f => f.MapFromNativeKey(NativeKey), Times.Once);
        }

        [Test]
        public void Mapping_CallsLockOptionsFactoryOnce()
        {
            // Arrange
            const Keys NativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(NativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputLocks(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputModifiers(true, true, true));

            // Act
            _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            _lockOptionsFactoryMock.Verify(f => f.Create(), Times.Once);
        }

        [Test]
        public void Mapping_CallsModifierOptionsFactoryOnce()
        {
            // Arrange
            const Keys NativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(NativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputLocks(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputModifiers(true, true, true));

            // Act
            _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            _modifierOptionsFactoryMock.Verify(f => f.Create(), Times.Once);
        }

        [Test]
        public void Mapping_ReturnesMappedInput()
        {
            // Arrange
            const Keys NativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(NativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputLocks(true, false, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new KeyboardInputModifiers(true, true, false));

            // Act
            var actualInput = _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            Assert.AreEqual(KeyboardInputDirection.KeyDown, actualInput.Direction);
            Assert.AreEqual(KeyboardInputKey.A, actualInput.InputKey);
            Assert.AreEqual(true, actualInput.Locks.IsCapsLockActive);
            Assert.AreEqual(false, actualInput.Locks.IsNumLockActive);
            Assert.AreEqual(true, actualInput.Locks.IsScrollLockActive);
            Assert.AreEqual(true, actualInput.Modifiers.IsAltPressed);
            Assert.AreEqual(true, actualInput.Modifiers.IsCtrlPressed);
            Assert.AreEqual(false, actualInput.Modifiers.IsShiftPressed);
        }

        [SetUp]
        public void SetUp()
        {
            _inputKeyMappingServantMock = new Mock<IKeyboardInputKeyMappingServant>();
            _lockOptionsFactoryMock = new Mock<IKeyboardInputLocksFactory>();
            _modifierOptionsFactoryMock = new Mock<IKeyboardInputModifiersFactory>();
            _sut = new KeyboardInputFactory(
                _inputKeyMappingServantMock.Object,
                _lockOptionsFactoryMock.Object,
                _modifierOptionsFactoryMock.Object);
        }
    }
}