using Xunit;
using static Checker;

public class CheckerTests
{
    public void EvaluateVitals_ReturnsCorrectStatus(float temp, int pulse, int spo2, VitalStatus expected)
    {
        var result = Checker.EvaluateVitals(temp, pulse, spo2);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void VitalsOk_ReturnsFalse_WhenAnyVitalIsOff()
    {
        Assert.False(Checker.VitalsOk(103f, 80, 95)); // High temp
        Assert.False(Checker.VitalsOk(98.6f, 55, 95)); // Low pulse
        Assert.False(Checker.VitalsOk(98.6f, 75, 85)); // Low SpO2
    }

    [Fact]
    public void VitalsOk_ReturnsTrue_WhenAllVitalsAreInRange()
    {
        Assert.True(Checker.VitalsOk(98.6f, 75, 95));
    }
}