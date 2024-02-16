using System;
using System.IO;
using ActivityLog.App;

namespace ActivityLog.Test;

public class UnitTest1
{
    private DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
    private DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
    private string testPath = @".\..\unitTestTextFile.txt";
    
    // Unit test 1
    [Fact]
    public void TestWorkActivity () {
        WorkActivity wa = new WorkActivity(start, end, 8, 1, "Revature");

        //Assert.IsType<Activity>(a);
        Assert.IsType<WorkActivity>(wa);
    }

    // Unit test 2
    [Fact]
    public void TestWorkActivitySerialization () {
        WorkActivity wa = new WorkActivity(start, end, 19, 400, "Nazem's", "Construction project!");

        // Serialize to file
        wa.SerializeXML(testPath);

        Assert.True(File.Exists(testPath));
    }

    // Unit test 3
    [Fact]
    public void TestWorkActivityDeserialization () {
        WorkActivity wa = new WorkActivity(start, end, 12, 0, "UTD FSA", "Catering event.");
        wa.SerializeXML(testPath);

        Assert.IsType<WorkActivity>(ActivityLog.App.WorkActivity.DeserializeXML(testPath));
    }

    [Theory]
    // Unit test 4
    [InlineData(15, 0, "Town Hall")]
    // Unit test 5
    [InlineData(17, 40, "Builder's Guild")]
    public void TestWorkActivityRevenue(double wage, double cost, string client) {
        WorkActivity wa = new WorkActivity(start, end, wage, cost, client);
        System.TimeSpan timeWorked = end - start;
        double expected = timeWorked.TotalHours * wage;

        double actual = wa.GetRevenue();
        
        Assert.IsType<double>(wa.GetRevenue());
        Assert.Equal(expected, actual);
    }

    [Theory]
    // Unit test 6
    [InlineData(33, 80, "Art Area")]
    // Unit test 7
    [InlineData(20, 105, "Georgie's")]
    public void TestWorkActivityProfit(double wage, double cost, string client) {
        WorkActivity wa = new WorkActivity(start, end, wage, cost, client);
        System.TimeSpan timeWorked = end - start;
        double expected = (timeWorked.TotalHours * wage) - cost;

        double actual = wa.GetProfit();

        Assert.IsType<double>(wa.GetProfit());
        Assert.Equal(expected, actual);
    }

    // Unit test 8
    [Fact]
    public void TestClimbing () {
        Climbing c = new Climbing(start, end, " yellow ", 3, "Momentum");

        Assert.IsType<Climbing>(c);
        // Checking constructor logic
        Assert.Equal(c.difficultyRecord, "YELLOW");
    }

    // Unit test 9
    [Fact]
    public void TestClimbingSerialization () {
        Climbing c = new Climbing(start, end, "blue", 11, "Houston", "weekend climb!");
        
        // Serialize to file
        c.SerializeXML(testPath);

        Assert.True(File.Exists(testPath));
    }

    // Unit test 10
    [Fact]
    public void TestClimbingDeserialization () {
        Climbing c = new Climbing(start, end, "blue", 11, "Houston", "weekend climb!");
        c.SerializeXML(testPath);

        Assert.IsType<Climbing>(ActivityLog.App.Climbing.DeserializeXML(testPath));
    }
}