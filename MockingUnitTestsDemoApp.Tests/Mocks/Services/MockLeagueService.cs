using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Tests.Mocks.Services
{
    public class MockLeagueService : Mock<ILeagueService>
    {
        public MockLeagueService MockIsValid(bool result)
        {
            Setup(x => x.IsValid(It.IsAny<int>()))
                .Returns(result);

            return this;
        }

        public MockLeagueService VerifyIsValid(Times times)
        {
            Verify(x => x.IsValid(It.IsAny<int>()), times);

            return this;
        }

        public MockLeagueService MockGetAll(List<League> results)
        {
            Setup(x => x.GetAll())
                .Returns(results);

            return this;
        }

        public MockLeagueService VerifyGetAll(Times times)
        {
            Verify(x => x.GetAll(), times);

            return this;
        }
    }
}
