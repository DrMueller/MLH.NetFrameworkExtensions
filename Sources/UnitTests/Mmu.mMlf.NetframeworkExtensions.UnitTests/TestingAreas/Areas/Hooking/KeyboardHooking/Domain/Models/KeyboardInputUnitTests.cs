using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.KeyboardHooking.Domain.Models
{
    [TestFixture]
    public class KeyboardInputUnitTests
    {
        [Test]
        public void CreatingOverview_CreatedOverview()
        {
            // Arrange
            var inputKey = KeyboardInputKey.Back;
            const bool IsShiftPressed = true;
            const bool IsAltPressed = false;
            const bool IsCtrlpressed = false;

            const bool IsScrollLockActive = true;
            const bool IsNumLockActive = false;
            const bool IsCapsLockActive = true;

            const KeyboardInputDirection InputDirection = KeyboardInputDirection.KeyDown;
            var inputLocks = new KeyboardInputLocks(IsScrollLockActive, IsNumLockActive, IsCapsLockActive);
            var inputModifiers = new KeyboardInputModifiers(IsCtrlpressed, IsAltPressed, IsShiftPressed);

            var sut = new KeyboardInput(inputKey, InputDirection, inputLocks, inputModifiers);

            // Act
            var actualOverview = sut.CreateOverview();

            // Assert
            var actualOverviewLines = actualOverview.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(8, actualOverviewLines.Length);
            Assert.AreEqual($"Key: {inputKey}", actualOverviewLines[0]);
            Assert.AreEqual($"Direction: {InputDirection}", actualOverviewLines[1]);
            Assert.AreEqual($"Modifier Shift: {IsShiftPressed}", actualOverviewLines[2]);
            Assert.AreEqual($"Modifier Ctrl: {IsCtrlpressed}", actualOverviewLines[3]);
            Assert.AreEqual($"Modifier Alt: {IsAltPressed}", actualOverviewLines[4]);
            Assert.AreEqual($"Lock Caps: {IsCapsLockActive}", actualOverviewLines[5]);
            Assert.AreEqual($"Lock Num: {IsNumLockActive}", actualOverviewLines[6]);
            Assert.AreEqual($"Lock Scroll: {IsScrollLockActive}", actualOverviewLines[7]);
        }
    }
}