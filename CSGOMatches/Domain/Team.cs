using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        public virtual List<PlayerInTeam> PlayerInTeams { get; set; }
    }
}
