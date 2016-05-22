using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class MatchFactory
    {
        public MatchDTO createBasicDTO(Match match, List<MapDTO> mapDTO)
        {
            return new MatchDTO
            {
                MatchId = match.MatchId,
                TeamOneName = match.TeamOne.Name,
                TeamTwoName = match.TeamTwo.Name,
                TeamOnePercentage = (match.TeamOneVotes.Value * 100) / (match.TeamOneVotes.Value + match.TeamTwoVotes.Value),
                TeamTwoPercentage = 100 - ((match.TeamOneVotes.Value * 100) / (match.TeamOneVotes.Value + match.TeamTwoVotes.Value)),
                Maps = mapDTO
            };
        }
    }
}
