using System;
using System.IO;
using ActivityLog.App;

namespace ActivityLog.Test;

public class UnitTest1
{
    private DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
    private DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
    private string testPath = @".\unitTestTextFile.txt";
    
    // Unit test 1
    [Fact]
    public void TestWorkActivity () {
        WorkActivity WA = new WorkActivity(start, end, 8, 1, "Revature");

        //Assert.IsType<Activity>(a);
        Assert.IsType<WorkActivity>(WA);
    }

    // Unit test 
    [Fact]
    public void TestClimbing () {
        Climbing C = new Climbing(start, end, " yellow ", 3, "Momentum");

        Assert.IsType<Climbing>(C);
        // Checking constructor logic
        Assert.Equal(C.difficultyRecord, "YELLOW");
    }

    // Unit test 
    [Fact]
    public void TestClimbSerialization () {
        Climbing C = new Climbing(start, end, "blue", 11, "Houston", "weekend climb!");
        
        string[] content = {C.SerializeXML()};
        File.WriteAllLines(testPath, content);

        Assert.True(File.Exists(testPath));
    }
}