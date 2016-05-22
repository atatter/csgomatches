using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PickedWinner
    {
        public int PickedWinnerId { get; set; }
        public int TimesChosenTeam1 { get; set; }
        public int TimesChosenTeam2 { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
