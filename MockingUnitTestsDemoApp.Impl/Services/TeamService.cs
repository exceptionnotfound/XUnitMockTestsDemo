using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services
{
public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepo;
    private readonly ILeagueRepository _leagueRepo;

    public TeamService(ITeamRepository teamRepo,
                        ILeagueRepository leagueRepo)
    {
        _teamRepo = teamRepo;
        _leagueRepo = leagueRepo;
    }

    public List<Team> Search(TeamSearch search)
    {
        //If we are searching for an invalid or unknown League...
        var isValidLeague = _leagueRepo.IsValid(search.LeagueID);
        if (!isValidLeague)
            return new List<Team>(); //Return an empty list.

        //Otherwise get all teams in the specified league...
        var allTeams = _teamRepo.GetForLeague(search.LeagueID);

        //... and filter them by the specified Founding Date and Direction.
        if(search.Direction == Enums.SearchDateDirection.OlderThan)
            return allTeams.Where(x => x.FoundingDate <= search.FoundingDate).ToList();
        else return allTeams.Where(x => x.FoundingDate >= search.FoundingDate).ToList();
    }
}
}
