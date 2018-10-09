using System;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configurations;
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
            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<MouseInput>())).Returns(Task.FromResult(true));
            _receiverMock.Setup(f => f.Configuration).Returns(actualConfiguration);

            _mouseInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeMouseInput>())).Returns(new MouseInput(MouseInputKey.Left, MouseInputDirection.MouseUp));

            Func<NativeMouseInput, bool> nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(
                It.IsAny<Func<NativeMouseInput, bool>>())
                ).Callback<Func<NativeMouseInput, bool>>(a => nativeInputCallback = a);

            _sut.HookMouse();
            var nativeKeyboardInput = new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp);

            // Act
            nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<MouseInput>()), Times.Once);
        }

        [Test]
        public void ReceivingNativeInput_ReceiverNotConfiguredForEvent_DoesNotCallReceiver()
        {
            // Arrange
            var mouseEventConfiguration = new MouseEventConfiguration(
                Option.CreateApplicible(MouseInputKey.Left),
                Option.CreateNotApplicable<MouseInputDirection>(true));

            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<MouseInput>()));
            _receiverMock.Setup(f => f.Configuration).Returns(mouseEventConfiguration);

            var mouseInput = new MouseInput(MouseInputKey.Right, MouseInputDirection.MouseUp);
            _mouseInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeMouseInput>())).Returns(mouseInput);

            Func<NativeMouseInput, bool> nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(
                It.IsAny<Func<NativeMouseInput, bool>>()
                )).Callback<Func<NativeMouseInput, bool>>(a => nativeInputCallback = a);

            _sut.HookMouse();
            var nativeKeyboardInput = new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp);

            // Act
            nativeInputCallback(nativeKeyboardInput);

            // Assert
            _receiverMock.Verify(f => f.ReceiveAsync(It.IsAny<MouseInput>()), Times.Never);
        }

        [Test]
        public void ReceivingNativeInput_WhenHooked_CallsFactoryWithReceivedInput()
        {
            // Arrange
            var configuration = MouseEventConfiguration.CreateForAllEvents();
            _receiverMock.Setup(f => f.Configuration).Returns(configuration);
            _receiverMock.Setup(f => f.ReceiveAsync(It.IsAny<MouseInput>())).Returns(Task.FromResult(true));

            Func<NativeMouseInput, bool> nativeInputCallback = null;
            _nativeMouseHookServiceMock.Setup(f => f.Hook(
                It.IsAny<Func<NativeMouseInput, bool>>()))
                .Callback<Func<NativeMouseInput, bool>>(a => nativeInputCallback = a);

            var mouseInput = new MouseInput(MouseInputKey.Right, MouseInputDirection.MouseUp);
            _mouseInputFactoryMock.Setup(f => f.Create(It.IsAny<NativeMouseInput>())).Returns(mouseInput);

            _sut.HookMouse();

            var nativeMouseInput = new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseDown);

            // Act
            nativeInputCallback(nativeMouseInput);

            // Assert
            _mouseInputFactoryMock.Verify(f => f.Create(nativeMouseInput), Times.Once);
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