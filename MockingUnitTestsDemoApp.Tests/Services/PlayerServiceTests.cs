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
    public class PlayerServiceTests
    {
        [Fact]
        public void PlayerService_GetForLeague_ValidCompleteLeague()
        {
            //Arrange
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var mockPlayers = new List<Player>()
            {
                new Player()
                {
                    ID = 1
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

            var playerService = new PlayerService(mockPlayerRepo.Object, 
                                                  mockTeamRepo.Object, 
                                                  mockLeagueRepo.Object);

            //Act
            var allPlayers = playerService.GetForLeague(1);

            //Assert
            Assert.NotEmpty(allPlayers);
            mockPlayerRepo.VerifyGetForTeam(Times.AtLeastOnce());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
            mockLeagueRepo.VerifyIsValid(Times.Once());
        }

        [Fact]
        public void PlayerService_GetForLeague_ValidLeagueNoPlayers()
        {
            //Arrange
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var mockPlayerRepo = new MockPlayerRepository().MockGetForTeam(new List<Player>());

            var mockTeams = new List<Team>()
            {
                new Team()
                {
                    ID = 1
                }
            };

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);

            var playerService = new PlayerService(mockPlayerRepo.Object, 
                                                  mockTeamRepo.Object,
                                                  mockLeagueRepo.Object);

            //Act
            var allPlayers = playerService.GetForLeague(1);

            //Assert
            Assert.Empty(allPlayers);
            mockPlayerRepo.VerifyGetForTeam(Times.AtLeastOnce());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
            mockLeagueRepo.VerifyIsValid(Times.Once());
        }

        [Fact]
        public void PlayerService_GetForLeague_ValidLeagueNoTeams()
        {
            //Arrange
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);
            var mockPlayerRepo = new MockPlayerRepository();
            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(new List<Team>());

            var playerService = new PlayerService(mockPlayerRepo.Object, 
                                                  mockTeamRepo.Object,
                                                  mockLeagueRepo.Object);

            //Act
            var allPlayers = playerService.GetForLeague(1);

            //Assert
            Assert.Empty(allPlayers);
            mockPlayerRepo.VerifyGetForTeam(Times.Never());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
            mockLeagueRepo.VerifyIsValid(Times.Once());
        }

        [Fact]
        public void PlayerService_GetForLeague_InvalidLeague()
        {
            //Arrange
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(false);

            var playerService = new PlayerService(new MockPlayerRepository().Object,
                                                    new MockTeamRepository().Object,
                                                    mockLeagueRepo.Object);

            //Act
            var allPlayers = playerService.GetForLeague(1);

            //Assert
            Assert.Empty(allPlayers);
            mockLeagueRepo.VerifyIsValid(Times.Once());
        }
    }
}
