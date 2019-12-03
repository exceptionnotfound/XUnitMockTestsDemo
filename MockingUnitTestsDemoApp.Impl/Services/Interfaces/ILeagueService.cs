using MockingUnitTestsDemoApp.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Services.Interfaces
{
    public interface ILeagueService
    {
        bool IsValid(int id);

        List<League> GetAll();
    }
}
