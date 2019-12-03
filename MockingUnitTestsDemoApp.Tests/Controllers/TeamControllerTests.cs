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
    public class TeamControllerTests
    {
        [Fact]
        public void TeamController_Search_Get_Valid()
        {
            //Arrange
            var teamResults = new List<Team>()
            {
                new Team()
                {
                    ID = 1
                }
            };

            var mockTeamService = new MockTeamService().MockSearch(teamResults);

            var controller = new TeamController(mockTeamService.Object);

            //Act
            var result = controller.Search();

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public void TeamController_Search_Post_Valid()
        {
            //Arrange
            var teamResults = new List<Team>()
            {
                new Team()
                {
                    ID = 1
                }
            };
            var mockTeamService = new MockTeamService().MockSearch(teamResults);

            var controller = new TeamController(mockTeamService.Object);

            //Act
            var result = controller.Search(new TeamSearch());

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTeamService.VerifySearch(Times.Once());
        }

        [Fact]
        public void TeamController_Search_Post_ModelStateInvalid()
        {
            //Arrange
            var teamResults = new List<Team>()
            {
                new Team()
                {
                    ID = 1
                }
            };

            var mockTeamService = new MockTeamService().MockSearch(teamResults);

            var controller = new TeamController(mockTeamService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            //Act
            var result = controller.Search(new TeamSearch());

            //Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockTeamService.VerifySearch(Times.Never());

            var redirectToAction = (RedirectToActionResult)result;
            Assert.Equal("Search", redirectToAction.ActionName);
        }

        [Fact]
        public void TeamController_Search_Post_NoResults()
        {
            //Arrange
            var mockTeamService = new MockTeamService().MockSearch(new List<Team>());

            var controller = new TeamController(mockTeamService.Object);

            //Act
            var result = controller.Search(new TeamSearch());

            //Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockTeamService.VerifySearch(Times.Once());
        }
    }
}
