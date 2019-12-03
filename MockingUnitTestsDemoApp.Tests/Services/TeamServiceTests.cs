using MockingUnitTestsDemoApp.Impl.Enums;
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
    public class TeamServiceTests
    {
        [Fact]
        public async Task TeamService_Search_OlderThan_Valid()
        {
            var mockTeams = GetMockTeams();

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var teamService = new TeamService(mockTeamRepo.Object, mockLeagueRepo.Object);

            var searchParams = new TeamSearch()
            {
                LeagueID = 1,
                FoundingDate = new DateTime(2013, 1, 1),
                Direction = SearchDateDirection.OlderThan
            };

            //Act
            var results = await teamService.Search(searchParams);

            Assert.NotEmpty(results);
            mockLeagueRepo.VerifyIsValid(Times.Once());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
        }

        [Fact]
        public async Task TeamService_Search_NewerThan_Valid()
        {
            var mockTeams = GetMockTeams();

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var teamService = new TeamService(mockTeamRepo.Object, mockLeagueRepo.Object);

            var searchParams = new TeamSearch()
            {
                LeagueID = 1,
                FoundingDate = new DateTime(1969, 1, 1),
                Direction = SearchDateDirection.NewerThan
            };

            //Act
            var results = await teamService.Search(searchParams);

            Assert.NotEmpty(results);
            mockLeagueRepo.VerifyIsValid(Times.Once());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
        }

        [Fact]
        public async Task TeamService_Search_OlderThan_Invalid()
        {
            var mockTeams = GetMockTeams();

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var teamService = new TeamService(mockTeamRepo.Object, mockLeagueRepo.Object);

            var searchParams = new TeamSearch()
            {
                LeagueID = 1,
                FoundingDate = new DateTime(1966, 1, 1),
                Direction = SearchDateDirection.OlderThan
            };

            //Act
            var results = await teamService.Search(searchParams);

            Assert.Empty(results);
            mockLeagueRepo.VerifyIsValid(Times.Once());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
        }

        [Fact]
        public async Task TeamService_Search_NewerThan_Invalid()
        {
            var mockTeams = GetMockTeams();

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(true);

            var teamService = new TeamService(mockTeamRepo.Object, mockLeagueRepo.Object);

            var searchParams = new TeamSearch()
            {
                LeagueID = 1,
                FoundingDate = new DateTime(2017, 1, 1),
                Direction = SearchDateDirection.NewerThan
            };

            //Act
            var results = await teamService.Search(searchParams);

            Assert.Empty(results);
            mockLeagueRepo.VerifyIsValid(Times.Once());
            mockTeamRepo.VerifyGetForLeague(Times.Once());
        }

        [Fact]
        public async Task TeamService_Search_InvalidLeague()
        {
            var mockTeams = GetMockTeams();

            var mockTeamRepo = new MockTeamRepository().MockGetForLeague(mockTeams);
            var mockLeagueRepo = new MockLeagueRepository().MockIsValid(false);

            var teamService = new TeamService(mockTeamRepo.Object, mockLeagueRepo.Object);

            var searchParams = new TeamSearch()
            {
                LeagueID = 1,
                FoundingDate = new DateTime(1997, 1, 1),
                Direction = SearchDateDirection.NewerThan
            };

            //Act
            var results = await teamService.Search(searchParams);

            Assert.Empty(results);
            mockLeagueRepo.VerifyIsValid(Times.Once());
            mockTeamRepo.VerifyGetForLeague(Times.Never());
        }

        private List<Team> GetMockTeams()
        {
            return new List<Team>()
            {
                new Team()
                {
                    ID = 1,
                    FoundingDate = new DateTime(1970, 1, 1)
                },
                new Team()
                {
                    ID = 2,
                    FoundingDate = new DateTime(1994, 12, 1)
                },
                new Team()
                {
                    ID = 3,
                    FoundingDate = new DateTime(2012, 5, 12)
                }
            };
        }
    }
}
