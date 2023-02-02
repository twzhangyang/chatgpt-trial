using School.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace School.Api.Tests;

public class MyDbContextTests
{
    [Fact(Skip = "test")]
    public void Test_Connection()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=school;Username=admin;Password=Password1;")
            .Options;

        // Act
        using (var context = new SchoolContext(options))
        {
            // Assert
            Assert.NotNull(context);
            Assert.IsType<SchoolContext>(context);
        }
    }
}
