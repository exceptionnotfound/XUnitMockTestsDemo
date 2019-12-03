using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public Task<Player> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetForTeam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
