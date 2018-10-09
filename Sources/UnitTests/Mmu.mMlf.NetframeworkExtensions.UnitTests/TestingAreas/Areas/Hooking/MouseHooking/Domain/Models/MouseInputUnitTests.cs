using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;
using NUnit.Framework;

namespace Mmu.Mlh.NetframeworkExtensions.UnitTests.TestingAreas.Areas.Hooking.MouseHooking.Domain.Models
{
    [TestFixture]
    public class MouseInputUnitTests
    {
        [Test]
        public void CreatingOverview_CreatedOverview()
        {
            // Arrange
            const MouseInputKey InputKey = MouseInputKey.Left;
            const MouseInputDirection InputDirection = MouseInputDirection.MouseUp;

            var sut = new MouseInput(InputKey, InputDirection);

            // Act
            var actualOverview = sut.CreateOverview();

            // Assert
            var actualOverviewLines = actualOverview.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(2, actualOverviewLines.Length);
            Assert.AreEqual($"Key: {InputKey}", actualOverviewLines[0]);
            Assert.AreEqual($"Direction: {InputDirection}", actualOverviewLines[1]);
        }
    }
}