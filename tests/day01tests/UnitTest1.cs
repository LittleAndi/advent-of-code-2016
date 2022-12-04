
namespace day01tests;

public class UnitTest1
{
    [Theory]
    [InlineData("R2, L3", 5)]
    [InlineData("R2, R2, R2", 2)]
    [InlineData("R5, L5, R5, R3", 12)]
    [InlineData("R2, R2, R2, R2, R2, L2", 4)]
    [InlineData("L2, L2, L2, L2, L2, R2", 4)]
    public void Test1(string directions, int expectedDistance)
    {
        var c = new CoordinateCalculator(directions);
        c.DistanceFromStart.ShouldBe(expectedDistance);
    }

    [Theory]
    [InlineData("R8, R4, R4, R4", 4)]
    public void Test2(string directions, int expectedDistance)
    {
        var c = new CoordinateCalculator(directions);
        c.DistanceOfFirstLocationVisitedTwice.ShouldBe(expectedDistance);
    }
}