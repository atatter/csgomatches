using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class TeamService
    {
        private ITeamRepository _teamRepo;
        private IPlayerRepository _playerRepo;
        private IPlayerInTeamRepository _playerInTeamRepo;
        private TeamFactory _factory;

        public TeamService()
        {
            _playerRepo = new PlayerRepository(new DataBaseContext());
            _teamRepo = new TeamRepository(new DataBaseContext());
            _playerInTeamRepo = new PlayerInTeamRepository(new DataBaseContext());
            _factory = new TeamFactory();
        }

        public List<TeamDTO> getTeams()
        {
            var teams = _teamRepo.All.ToList();
            List<TeamDTO> teamDTOs = new List<TeamDTO>();
            

            foreach (var team in teams)
            {
                List<int> ints = new List<int>();
                List<string> strings = new List<string>();

                var playersInTeam = _playerInTeamRepo.All.Where(x => x.TeamId == team.TeamId).ToList();

                foreach (var playerInTeam in playersInTeam)
                {
                    ints.Add(playerInTeam.PlayerId);
                    strings.Add(playerInTeam.Player.Nick);
                }

                var theInts = ints.ToArray();
                teamDTOs.Add(_factory.createBasicDTO(team, theInts, strings));

            }

            return teamDTOs;
        }

        public TeamDTO getTeamById(int id)
        {
            var team = getTeams().Where(x => x.TeamId == id);
            if (team.Any())
            {
                return team.FirstOrDefault();
            }
            
            return null;
        }

        public bool editTeam(string name, int[] playerIds, int teamId)
        {
            var team = _teamRepo.GetById(teamId);
            if (team == null)
            {
                return false;
            }
            team.Name = name;
            _teamRepo.Update(team);
            _teamRepo.SaveChanges();

            var previousPlayers = _playerInTeamRepo.All.Where(x => x.TeamId == teamId).ToList();

            foreach (var previousPlayer in previousPlayers)
            {
                _playerInTeamRepo.Delete(previousPlayer.PlayerInTeamId);
            }

            foreach (var playerId in playerIds)
            {
                var player = _playerRepo.GetById(playerId);
                if (player == null)
                {
                    return false;
                }
                PlayerInTeam playerInTeam = new PlayerInTeam { Active = true, PlayerId = playerId, TeamId = team.TeamId };
                _playerInTeamRepo.Add(playerInTeam);
            }

            _playerInTeamRepo.SaveChanges();

            return true;
        }

        public bool addTeam(string name, int[] playerIds)
        {
            Team team = new Team();
            team.Name = name;
            _teamRepo.Add(team);
            _teamRepo.SaveChanges();
            foreach (var playerId in playerIds)
            {
                var player = _playerRepo.GetById(playerId);
                if (player == null)
                {
                    return false;
                }
                PlayerInTeam playerInTeam = new PlayerInTeam { Active = true, PlayerId = playerId, TeamId = team.TeamId };
                _playerInTeamRepo.Add(playerInTeam);
            }

            _playerInTeamRepo.SaveChanges();

            return true;
        }
    }
}
