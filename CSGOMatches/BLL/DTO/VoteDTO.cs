using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class VoteDTO
    {
        public int MatchId { get; set; }
        public bool VoteForTeamOne { get; set; }
        public bool VoteForTeamTwo { get; set; }
    }
}
