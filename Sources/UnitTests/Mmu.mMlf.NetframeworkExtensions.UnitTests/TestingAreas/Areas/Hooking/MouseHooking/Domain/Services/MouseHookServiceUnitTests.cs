using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configuration;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;
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
        private Mock<IMouseInputReceiver> _receiverMock;
        private MouseHookService _sut;

        [Test]
        public void ReceivingNativeInput_ReceiverConfiguredForAllEvents_CallsReceiver()
        {
            // Arrange
            var actualConfiguration = MouseEventConfiguration.CreateForAllEvents();
            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<MouseInput>()));
            _receiverMock.Setup(f => f.Configuration).Returns(actualConfiguration);

            _mouseInputFactoryMock.Setup(f => f.CreateFromNativeMouseInput(It.IsAny<NativeMouseInput>())).Returns(new MouseInput(MouseInputKey.Left, MouseInputDirection.MouseUp));

            Action<NativeMouseInput> _nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeMouseInput>>())).Callback<Action<NativeMouseInput>>(a => _nativeInputCallback = a);

            _sut.HookMouse();
            var nativeKeyboardInput = new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp);

            // Act
            _nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<MouseInput>()), Times.Once);
        }

        [Test]
        public void ReceivingNativeInput_ReceiverNotConfiguredForEvent_DoesNotCallReceiver()
        {
            // Arrange
            var mouseInput = new MouseInput(MouseInputKey.Right, MouseInputDirection.MouseUp);
            var mouseEventConfiguration = new MouseEventConfiguration(
                Option.CreateApplicible(MouseInputKey.Left),
                Option.CreateNotApplicable<MouseInputDirection>(true));

            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<MouseInput>()));
            _receiverMock.Setup(f => f.Configuration).Returns(mouseEventConfiguration);

            _mouseInputFactoryMock.Setup(f => f.CreateFromNativeMouseInput(It.IsAny<NativeMouseInput>())).Returns(mouseInput);

            Action<NativeMouseInput> _nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeMouseInput>>())).Callback<Action<NativeMouseInput>>(a => _nativeInputCallback = a);

            _sut.HookMouse();
            var nativeKeyboardInput = new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp);

            // Act
            _nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<MouseInput>()), Times.Never);
        }

        [Test]
        public void ReceivingNativeInput_WhenHooked_CallsFactoryWithReceivedInput()
        {
            // Arrange
            Action<NativeMouseInput> _nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(It.IsAny<Action<NativeMouseInput>>())).Callback<Action<NativeMouseInput>>(a => _nativeInputCallback = a);
            _mouseInputFactoryMock.Setup(f => f.CreateFromNativeMouseInput(It.IsAny<NativeMouseInput>()));

            _sut.HookMouse();

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
            _receiverMock = new Mock<IMouseInputReceiver>();
            _sut = new MouseHookService(
                _nativeMouseHookServiceMock.Object,
                _mouseInputFactoryMock.Object,
                new[] { _receiverMock.Object });
        }
    }
}