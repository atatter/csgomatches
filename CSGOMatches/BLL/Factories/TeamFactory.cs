using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class TeamFactory
    {
        public TeamDTO createBasicDTO(Team team, int[] playerIds, List<string> players )
        {
            return new TeamDTO { Name = team.Name, TeamId = team.TeamId, PlayerIds = playerIds, PlayerList = players};
        }
    }
}
