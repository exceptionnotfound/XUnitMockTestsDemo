using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Team GetByID(int id);
        List<Team> GetForLeague(int leagueID);
    }
}
