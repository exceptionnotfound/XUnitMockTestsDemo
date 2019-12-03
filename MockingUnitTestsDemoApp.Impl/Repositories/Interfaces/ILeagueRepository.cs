using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        League GetByID(int id);
        List<League> GetAll();
        bool IsValid(int leagueID);
    }
}
