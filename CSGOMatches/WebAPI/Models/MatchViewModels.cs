using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebAPI.Models
{
    public class MatchVoteViewModel
    {
        public int MatchId { get; set; }
        public bool VoteForTeamOne { get; set; }
        public bool VoteForTeamTwo { get; set; }
    }

    public class MatchCreateViewModel
    {
        public Match Match { get; set; }
        public int TeamOneId { get; set; }
        public int TeamTwoId { get; set; }
        public int[] MapIds { get; set; }
    }
}