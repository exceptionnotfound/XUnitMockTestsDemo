using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> Search(TeamSearch search);
    }
}
