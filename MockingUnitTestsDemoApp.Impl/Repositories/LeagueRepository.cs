using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        public League GetByID(int leagueID)
        {
            throw new NotImplementedException();
        }

        public List<League> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(int leagueID)
        {
            throw new NotImplementedException();
        }
    }
}
