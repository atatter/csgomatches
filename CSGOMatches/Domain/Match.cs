using System;
using System.Collections.Generic;
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


        public int Team1Id { get; set; }
        public virtual Team Team1 { get; set; }

        public int Team2Id { get; set; }
        public virtual Team Team2 { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<PickedWinner> PickedWinner { get; set; }

        public virtual List<PickedMVP> PickedMvps { get; set; }
       
    }
}
