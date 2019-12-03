using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Services;
using MockingUnitTestsDemoApp.Tests.Mocks.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockingUnitTestsDemoApp.Tests.Services
{
    public class LeagueServiceTests
    {
        [Fact]
        public async Task LeagueService_GetAllPlayers_ValidCompleteLeague()
        {
            //Arrange
            var mockPlayers = new List<Player>()
            {
                new Player()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "Test"
                }
            };

            var mockPlayerRepo = new MockPlayerRepository().MockGetForTeam(mockPlayers);

            var mockTeams = new List<Team>()
            {
                new Team()
                {
                    ID = 1
                }
            };

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);

            var leagueService = new LeagueService(mockPlayerRepo.Object, mockTeamRepo.Object);

            //Act
            var allPlayers = await leagueService.GetAllPlayers(1);

            //Assert
            Assert.NotEmpty(allPlayers);
            mockPlayerRepo.VerifyGetForTeam(Times.AtLeastOnce());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
        }
    }
}
