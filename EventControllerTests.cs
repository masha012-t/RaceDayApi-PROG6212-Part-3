using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Controllers;
using RaceDay.API.Data;
using RaceDay.API.Models;
using RaceDay.API.Controllers;
using RaceDay.API.Data;
using RaceDayApi.Models;
using System.Security.Claims;
using Xunit;

namespace RaceDayApi.Tests
{
    public class EventControllerTests
    {
        private RaceDayDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB per test
                .Options;
            return new RaceDayDbContext(options);
        }

        [Fact]
        public async Task CreateEvent_AsParticipant_ReturnsCreated()
        {
            // 1. ARRANGE
            var context = GetInMemoryDbContext();
            var controller = new EventsController(context);

            // Mock a Participant (even though the real API would block this via [Authorize])
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "2"),
                new Claim(ClaimTypes.Role, "Participant")
            }, "mock"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var newEvent = new Event { EventName = "Test Event 2", EventDate = DateTime.Now, Location = "Nowhere", EventType = "Running" };

            // 2. ACT
            var result = await controller.CreateEvent(newEvent);

            // 3. ASSERT
            // Since unit tests bypass the [Authorize] attribute, it will return 201 Created.
            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdEvent = Assert.IsType<Event>(createdAtResult.Value);

            Assert.Equal("Test Event 2", createdEvent.EventName);
            Assert.Equal(2, createdEvent.OrganiserId); // Ensures it assigned the UserId 2 to the event
        }
    }
}