using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Tests.Mocks.Repositories
{
public class MockTeamRepository : Mock<ITeamRepository>
{
    public MockTeamRepository MockGetByID(Team result)
    {
        Setup(x => x.GetByID(It.IsAny<int>()))
            .Returns(result);

        return this;
    }

    public MockTeamRepository MockGetByIDInvalid()
    {
        Setup(x => x.GetByID(It.IsAny<int>()))
            .Throws(new Exception());

        return this;
    }

    public MockTeamRepository VerifyGetByID(Times times)
    {
        Verify(x => x.GetByID(It.IsAny<int>()), times);

        return this;
    }

    public MockTeamRepository MockGetForLeague(List<Team> results)
    {
        Setup(x => x.GetForLeague(It.IsAny<int>()))
            .Returns(results);

        return this;
    }

    public MockTeamRepository VerifyGetForLeague(Times times)
    {
        Verify(x => x.GetForLeague(It.IsAny<int>()), times);

        return this;
    }
}
}
