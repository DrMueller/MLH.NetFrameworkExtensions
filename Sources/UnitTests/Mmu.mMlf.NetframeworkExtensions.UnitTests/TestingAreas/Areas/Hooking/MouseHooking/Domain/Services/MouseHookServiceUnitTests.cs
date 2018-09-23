using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.MouseHooking.Domain.Services
{
    [TestFixture]
    public class MouseHookServiceUnitTests
    {
        private Mock<IMouseInputFactory> _mouseInputFactoryMock;
        private Mock<INativeMouseHookService> _nativeMouseHookServiceMock;
        private MouseHookService _sut;

        [Test]
        public void ReceivingNativeInput_WhenHooked_CallsCallback()
        {
            // Arrange
            Action<NativeMouseInput> _nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeMouseInput>>())).Callback<Action<NativeMouseInput>>(a => _nativeInputCallback = a);
            _mouseInputFactoryMock.Setup(f => f.CreateFromNativeMouseInput(It.IsAny<NativeMouseInput>()));

            var callbackHasBeenCalled = false;
            _sut.HookMouse(
                keyboardInput =>
                {
                    callbackHasBeenCalled = true;
                });

            var nativeKeyboardInput = new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp);

            // Act
            _nativeInputCallback(nativeKeyboardInput);

            // Assert
            Assert.IsTrue(callbackHasBeenCalled);
        }

        [Test]
        public void ReceivingNativeInput_WhenHooked_CallsFactoryWithReceivedInput()
        {
            // Arrange
            Action<NativeMouseInput> _nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeMouseInput>>())).Callback<Action<NativeMouseInput>>(a => _nativeInputCallback = a);
            _mouseInputFactoryMock.Setup(f => f.CreateFromNativeMouseInput(It.IsAny<NativeMouseInput>()));

            _sut.HookMouse(
                keyboardInput =>
                {
                });

            var nativeMouseInput = new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseDown);

            // Act
            _nativeInputCallback(nativeMouseInput);

            // Assert
            _mouseInputFactoryMock.Verify(f => f.CreateFromNativeMouseInput(nativeMouseInput), Times.Once);
        }

        [SetUp]
        public void SetUp()
        {
            _nativeMouseHookServiceMock = new Mock<INativeMouseHookService>();
            _mouseInputFactoryMock = new Mock<IMouseInputFactory>();
            _sut = new MouseHookService(_nativeMouseHookServiceMock.Object, _mouseInputFactoryMock.Object);
        }
    }
}