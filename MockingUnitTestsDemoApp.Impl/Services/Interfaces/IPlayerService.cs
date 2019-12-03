using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services.Interfaces
{
    public interface IPlayerService
    {
        Player GetByID(int id);

        List<Player> GetForLeague(int leagueID);
    }
}
