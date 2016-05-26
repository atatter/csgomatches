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
            var teamonepercentage = new int();
            var teamtwopercentage = new int();
            if (match.TeamOneVotes == 0 && match.TeamTwoVotes == 0)
            {
                teamonepercentage = 50;
                teamtwopercentage = 50;
            } else if (match.TeamOneVotes == 1 && match.TeamTwoVotes == 0)
            {
                teamonepercentage = 100;
                teamtwopercentage = 0;
            } else if (match.TeamOneVotes == 0 && match.TeamTwoVotes == 1)
            {
                teamonepercentage = 0;
                teamtwopercentage = 100;
            }
            else
            {
                teamonepercentage = (match.TeamOneVotes.Value * 100) / (match.TeamOneVotes.Value + match.TeamTwoVotes.Value);
                teamtwopercentage = 100 - ((match.TeamOneVotes.Value * 100) / (match.TeamOneVotes.Value + match.TeamTwoVotes.Value));
            }
            
            return new MatchDTO
            {
                MatchId = match.MatchId,
                TeamOneName = match.TeamOne.Name,
                TeamTwoName = match.TeamTwo.Name,
                TeamOnePercentage = teamonepercentage,
                TeamTwoPercentage = teamtwopercentage,
                Maps = mapDTO
            };
        }
    }
}
