using Microsoft.AspNetCore.Mvc;
using MockingUnitTestsDemoApp.Controllers;
using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Tests.Mocks.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MockingUnitTestsDemoApp.Tests.Controllers
{
    public class LeagueControllerTests
    {
        [Fact]
        public void LeagueController_Index_LeaguesExist()
        {
            //Arrange
            var mockLeagues = new List<League>()
            {
                new League()
                {
                    ID = 1,
                    FoundingDate = new DateTime(1933, 5, 3)
                }
            };

            var mockLeagueService = new MockLeagueService().MockGetAll(mockLeagues);

            var controller = new LeagueController(mockLeagueService.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockLeagueService.VerifyGetAll(Times.Once());
        }

        [Fact]
        public void LeagueController_Index_NoLeagues()
        {
            //Arrange
            var mockLeagueService = new MockLeagueService().MockGetAll(new List<League>());

            var controller = new LeagueController(mockLeagueService.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockLeagueService.VerifyGetAll(Times.Once());
        }
    }
}
