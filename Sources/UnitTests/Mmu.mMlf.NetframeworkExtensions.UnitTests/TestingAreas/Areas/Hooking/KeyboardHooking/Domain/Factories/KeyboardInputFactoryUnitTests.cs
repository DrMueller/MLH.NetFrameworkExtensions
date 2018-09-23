using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.KeyboardHooking.Domain.Factories
{
    [TestFixture]
    public class KeyboardInputFactoryUnitTests
    {
        private Mock<IKeyboardInputKeyMappingServant> _inputKeyMappingServantMock;
        private Mock<ILockOptionsFactory> _lockOptionsFactoryMock;
        private Mock<IModifierOptionsFactory> _modifierOptionsFactoryMock;
        private KeyboardInputFactory _sut;

        [Test]
        public void Mapping_CallsInputKeyMappingServantOnceWithPassedNativeKey()
        {
            // Arrange
            const Keys nativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(nativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new LockOptions(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new ModifierOptions(true, true, true));

            // Act
            _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            _inputKeyMappingServantMock.Verify(f => f.MapFromNativeKey(nativeKey), Times.Once);
        }

        [Test]
        public void Mapping_CallsLockOptionsFactoryOnce()
        {
            // Arrange
            const Keys NativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(NativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new LockOptions(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new ModifierOptions(true, true, true));

            // Act
            _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            _lockOptionsFactoryMock.Verify(f => f.Create(), Times.Once);
        }

        [Test]
        public void Mapping_CallsModifierOptionsFactoryOnce()
        {
            // Arrange
            const Keys nativeKey = Keys.A;
            var nativeKeyboardInput = new NativeKeyboardInput(nativeKey, NativeKeyboardInputDirection.KeyDown);

            _inputKeyMappingServantMock.Setup(f => f.MapFromNativeKey(Keys.A)).Returns(KeyboardInputKey.A);
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new LockOptions(true, true, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new ModifierOptions(true, true, true));

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
            _lockOptionsFactoryMock.Setup(f => f.Create()).Returns(new LockOptions(true, false, true));
            _modifierOptionsFactoryMock.Setup(f => f.Create()).Returns(new ModifierOptions(true, true, false));

            // Act
            var actualInput = _sut.CreateFromNativeKeyboardInput(nativeKeyboardInput);

            // Assert
            Assert.AreEqual(KeyboardInputDirection.KeyDown, actualInput.Direction);
            Assert.AreEqual(KeyboardInputKey.A, actualInput.InputKey);
            Assert.AreEqual(true, actualInput.LockOptions.IsCapsLockActive);
            Assert.AreEqual(false, actualInput.LockOptions.IsNumLockActive);
            Assert.AreEqual(true, actualInput.LockOptions.IsScrollLockActive);
            Assert.AreEqual(true, actualInput.ModifierOptions.IsAltPressed);
            Assert.AreEqual(true, actualInput.ModifierOptions.IsCtrlPressed);
            Assert.AreEqual(false, actualInput.ModifierOptions.IsShiftPressed);
        }

        [SetUp]
        public void SetUp()
        {
            _inputKeyMappingServantMock = new Mock<IKeyboardInputKeyMappingServant>();
            _lockOptionsFactoryMock = new Mock<ILockOptionsFactory>();
            _modifierOptionsFactoryMock = new Mock<IModifierOptionsFactory>();
            _sut = new KeyboardInputFactory(
                _inputKeyMappingServantMock.Object,
                _lockOptionsFactoryMock.Object,
                _modifierOptionsFactoryMock.Object);
        }
    }
}