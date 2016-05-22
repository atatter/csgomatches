using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Match
    {
        public Match()
        {
            Created = DateTime.Now;
        }

        public int MatchId { get; set; }
        public DateTime Created { get; set; }

        public int? TeamOneVotes { get; set; }
        public int? TeamTwoVotes { get; set; }

        [ForeignKey(nameof(TeamOne))]
        public int? TeamOneId { get; set; }
        public virtual Team TeamOne { get; set; }

        [ForeignKey(nameof(TeamTwo))]
        public int? TeamTwoId { get; set; }
        public virtual Team TeamTwo { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<PickedMVP> PickedMvps { get; set; }
       
    }
}
