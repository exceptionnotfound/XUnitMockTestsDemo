using Microsoft.AspNetCore.Mvc;
using MockingUnitTestsDemoApp.Controllers;
using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Tests.Mocks;
using MockingUnitTestsDemoApp.Tests.Mocks.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MockingUnitTestsDemoApp.Tests.Controllers
{
    public class PlayerControllerTests
    {
        [Fact]
        public void PlayerController_Index_Valid()
        {
            //Arrange
            var mockPlayer = new Player()
            {
                ID = 1
            };

            var mockPlayerService = new MockPlayerService().MockGetByID(mockPlayer);

            var controller = new PlayerController(new MockLeagueService().Object,
                                                  mockPlayerService.Object);

            //Act
            var result = controller.Index(1);

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockPlayerService.VerifyGetByID(Times.Once());
        }

        [Fact]
        public void PlayerController_Index_Invalid()
        {
            //Arrange
            var mockPlayerService = new MockPlayerService().MockGetByIDInvalid();

            var controller = new PlayerController(new MockLeagueService().Object,
                                                  mockPlayerService.Object);

            //Act
            var result = controller.Index(1);

            //Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockPlayerService.VerifyGetByID(Times.Once());
        }

        [Fact]
        public void PlayerController_League_Valid()
        {
            //Arrange
            var mockPlayers = new List<Player>()
            {
                new Player()
                {
                    ID = 1
                }
            };

            var mockLeagueService = new MockLeagueService().MockIsValid(true);
            var mockPlayerService = new MockPlayerService().MockGetForLeague(mockPlayers);

            var controller = new PlayerController(mockLeagueService.Object,
                                                  mockPlayerService.Object);

            //Act
            var result = controller.League(1);

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockPlayerService.VerifyGetForLeague(Times.Once());
            mockLeagueService.VerifyIsValid(Times.Once());
        }

        [Fact]
        public void PlayerController_League_Invalid()
        {
            //Arrange
            var mockLeagueService = new MockLeagueService().MockIsValid(false);
            var mockPlayerService = new MockPlayerService().MockGetForLeague(new List<Player>());

            var controller = new PlayerController(mockLeagueService.Object,
                                                  mockPlayerService.Object);

            //Act
            var result = controller.League(1);

            //Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockPlayerService.VerifyGetForLeague(Times.Never());
            mockLeagueService.VerifyIsValid(Times.Once());
        }
    }
}
