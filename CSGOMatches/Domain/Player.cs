using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Nick { get; set; }

        public virtual List<PlayerInTeam> PlayerInTeams { get; set; }
        public virtual List<PickedMVP> PickedMvps { get; set; }
    }
}
