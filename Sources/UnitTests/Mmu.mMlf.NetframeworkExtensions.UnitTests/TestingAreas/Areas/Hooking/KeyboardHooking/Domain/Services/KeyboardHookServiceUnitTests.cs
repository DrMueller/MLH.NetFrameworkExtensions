using System;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
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

        //[Test]
        //public void ReceivingNativeInput_WhenHooked_CallsFactoryWithReceivedInput()
        //{
        //    // Arrange
        //    Action<NativeKeyboardInput> _nativeInputCallback = null;
        //    _nativeKeyboardHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeKeyboardInput>>())).Callback<Action<NativeKeyboardInput>>(a => _nativeInputCallback = a);
        //    _keyboardInputFactoryMock.Setup(f => f.CreateFromNativeKeyboardInput(It.IsAny<NativeKeyboardInput>()));

        //    _sut.HookKeyboard(
        //        keyboardInput =>
        //        {
        //        });

        //    var nativeKeyboardInput = new NativeKeyboardInput(Keys.A, NativeKeyboardInputDirection.KeyDown);

        //    // Act
        //    _nativeInputCallback(nativeKeyboardInput);

        //    // Assert
        //    _keyboardInputFactoryMock.Verify(f => f.CreateFromNativeKeyboardInput(nativeKeyboardInput), Times.Once);
        //}

        //[Test]
        //public void ReceivingNativeInput_WhenHooked_CallsCallback()
        //{
        //    // Arrange
        //    Action<NativeKeyboardInput> _nativeInputCallback = null;
        //    _nativeKeyboardHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeKeyboardInput>>())).Callback<Action<NativeKeyboardInput>>(a => _nativeInputCallback = a);
        //    _keyboardInputFactoryMock.Setup(f => f.CreateFromNativeKeyboardInput(It.IsAny<NativeKeyboardInput>()));

        //    var callbackHasBeenCalled = false;
        //    _sut.HookKeyboard(
        //        keyboardInput =>
        //        {
        //            callbackHasBeenCalled = true;
        //        });

        //    var nativeKeyboardInput = new NativeKeyboardInput(Keys.A, NativeKeyboardInputDirection.KeyDown);

        //    // Act
        //    _nativeInputCallback(nativeKeyboardInput);

        //    // Assert
        //    Assert.IsTrue(callbackHasBeenCalled);
        //}

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