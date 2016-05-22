using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlayerInTeam
    {
        public int PlayerInTeamId { get; set; }
        public bool Active { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
