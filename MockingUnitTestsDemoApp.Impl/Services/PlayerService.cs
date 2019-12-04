using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services
{
public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepo;
    private readonly ITeamRepository _teamRepo;
    private readonly ILeagueRepository _leagueRepo;

    public PlayerService(IPlayerRepository playerRepo,
                            ITeamRepository teamRepo,
                            ILeagueRepository leagueRepo)
    {
        _playerRepo = playerRepo;
        _teamRepo = teamRepo;
        _leagueRepo = leagueRepo;
    }

    public Player GetByID(int id)
    {
        return _playerRepo.GetByID(id);
    }

    public List<Player> GetForLeague(int leagueID)
    {
        var isValidLeague = _leagueRepo.IsValid(leagueID);
        if (!isValidLeague)
            return new List<Player>();

        List<Player> players = new List<Player>();

        var teams = _teamRepo.GetForLeague(leagueID);

        foreach(var team in teams)
        {
            players.AddRange(_playerRepo.GetForTeam(team.ID));
        }

        return players;
    }
}
}
