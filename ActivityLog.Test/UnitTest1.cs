using ActivityLog.App;

namespace ActivityLog.Test;

public class UnitTest1
{
    // Unit test 1
    [Fact]
    public void TestWorkActivity () {
        DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
        DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
        WorkActivity wa = new WorkActivity(start, end, 8, 1, "Revature");

        //Assert.IsType<Activity>(a);
        Assert.IsType<WorkActivity>(wa);
    }

    // Unit test 2
    [Fact]
    public void TestClimbing () {
        DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
        DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
        Climbing c = new Climbing(start, end, " yellow ", 3, "Momentum");

        Assert.IsType<Climbing>(c);
        // Checking constructor logic
        Assert.Equal(c.difficultyRecord, "YELLOW");
    }

    
}