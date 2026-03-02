using Microsoft.EntityFrameworkCore;
using Xunit;

using CaseProject;
namespace Data
{
    public class DataIntegrationTeste
    {

        [Fact]
        // Act + Arrange
        public async Task ConectionDataBase(){
            var opitons = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql("Host=localhost;Port=5432;Database=minhaapi_db;Username=postgres;Password=postgres;").Options;
            using var context = new AppDbContext(opitons);
            var canConnnection = await context.Database.CanConnectAsync();
            // Assert 
            Assert.True(canConnnection);
        } 
    }
}