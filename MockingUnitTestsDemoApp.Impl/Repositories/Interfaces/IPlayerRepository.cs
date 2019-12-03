using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetByID(int id);
        List<Player> GetForTeam(int id);
    }
}
