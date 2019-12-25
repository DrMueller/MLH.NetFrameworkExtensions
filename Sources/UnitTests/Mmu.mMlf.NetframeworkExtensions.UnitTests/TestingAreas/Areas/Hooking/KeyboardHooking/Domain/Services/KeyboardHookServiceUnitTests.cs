using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.KeyboardHooking.Domain.Services
{
    [TestFixture]
    public class KeyboardHookServiceUnitTests
    {
        private Mock<IKeyboardInputFactory> _keyboardInputFactoryMock;
        private Mock<INativeKeyboardHookService> _nativeKeyboardHookServiceMock;
        private Mock<IKeyboardInputReceiver> _receiverMock;
        private KeyboardHookService _sut;

        [Test]
        public void ReceivingNativeInput_ReceiverConfiguredForAllEvents_CallsReceiver()
        {
            // Arrange
            var keyboardEventConfiguration = KeyboardEventConfiguration.CreateForAllEvents();

            var keyboardInput = new KeyboardInput(
                KeyboardInputKey.A,
                KeyboardInputDirection.KeyDown,
                new KeyboardInputLocks(false, false, false),
                new KeyboardInputModifiers(true, false, false));

            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<KeyboardInput>())).Returns(Task.FromResult(true));
            _receiverMock.Setup(f => f.Configuration).Returns(keyboardEventConfiguration);
            _keyboardInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeKeyboardInput>())).Returns(keyboardInput);

            Action<NativeKeyboardInput> nativeInputCallback = null;
            _nativeKeyboardHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeKeyboardInput>>())).Callback<Action<NativeKeyboardInput>>(
                func =>
                {
                    nativeInputCallback = func;
                });

            _sut.HookKeyboard();
            var nativeKeyboardInput = new NativeKeyboardInput(Keys.A, NativeKeyboardInputDirection.KeyDown);

            // Act
            nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<KeyboardInput>()), Times.Once);
        }

        [Test]
        public void ReceivingNativeInput_ReceiverNotConfiguredForEvent_DoesNotCallReceiver()
        {
            // Arrange
            const bool ScrollLockMustBeActive = true;

            var keyboardInput = new KeyboardInput(
                KeyboardInputKey.A,
                KeyboardInputDirection.KeyDown,
                new KeyboardInputLocks(false, false, false),
                new KeyboardInputModifiers(!ScrollLockMustBeActive, false, false));

            var keyboardEventConfiguration = new KeyboardEventConfiguration(
                new KeyboardInputKeyConfiguration(KeyboardInputKey.AllKeys.ToArray()),
                ModifierConfiguration.CreateNotApplicable(),
                new LockConfiguration(ScrollLockMustBeActive, false, false));

            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<KeyboardInput>())).Returns(Task.FromResult(true));
            _receiverMock.Setup(f => f.Configuration).Returns(keyboardEventConfiguration);

            _keyboardInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeKeyboardInput>())).Returns(keyboardInput);

            Action<NativeKeyboardInput> nativeInputCallback = null;
            _nativeKeyboardHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeKeyboardInput>>())).Callback<Action<NativeKeyboardInput>>(a => nativeInputCallback = a);

            _sut.HookKeyboard();
            var nativeKeyboardInput = new NativeKeyboardInput(Keys.Alt, NativeKeyboardInputDirection.KeyUp);

            // Act
            nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<KeyboardInput>()), Times.Never);
        }

        [Test]
        public void ReceivingNativeInput_WhenHooked_CallsFactoryWithReceivedInput()
        {
            // Arrange
            Action<NativeKeyboardInput> nativeInputCallback  = null;
            _nativeKeyboardHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeKeyboardInput>>())).Callback<Action<NativeKeyboardInput>>(a => nativeInputCallback = a);
            _keyboardInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeKeyboardInput>()));

            var keyboardInput = new KeyboardInput(
                KeyboardInputKey.A,
                KeyboardInputDirection.KeyDown,
                new KeyboardInputLocks(false, false, false),
                new KeyboardInputModifiers(!false, false, false));

            _keyboardInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeKeyboardInput>())).Returns(keyboardInput);

            var keyboardEventConfiguration = new KeyboardEventConfiguration(
                new KeyboardInputKeyConfiguration(KeyboardInputKey.AllKeys.ToArray()),
                ModifierConfiguration.CreateNotApplicable(),
                LockConfiguration.CreateNotApplicable());

            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<KeyboardInput>())).Returns(Task.FromResult(true));
            _receiverMock.Setup(f => f.Configuration).Returns(keyboardEventConfiguration);
            _sut.HookKeyboard();

            var nativeKeyboardInput = new NativeKeyboardInput(Keys.A, NativeKeyboardInputDirection.KeyDown);

            // Act
            nativeInputCallback(nativeKeyboardInput);

            // Assert
            _keyboardInputFactoryMock.Verify(f => f.Create(nativeKeyboardInput), Times.Once);
        }

        [SetUp]
        public void SetUp()
        {
            _nativeKeyboardHookServiceMock = new Mock<INativeKeyboardHookService>();
            _keyboardInputFactoryMock = new Mock<IKeyboardInputFactory>();
            _receiverMock = new Mock<IKeyboardInputReceiver>();
            _sut = new KeyboardHookService(
                _nativeKeyboardHookServiceMock.Object,
                _keyboardInputFactoryMock.Object,
                new[] { _receiverMock.Object });
        }
    }
}