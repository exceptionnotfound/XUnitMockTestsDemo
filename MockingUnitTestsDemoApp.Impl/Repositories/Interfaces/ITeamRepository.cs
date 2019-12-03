using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetByID(int id);
        Task<List<Team>> GetForLeague(int leagueID);
    }
}
