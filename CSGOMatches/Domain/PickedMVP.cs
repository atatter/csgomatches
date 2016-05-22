using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PickedMVP
    {
        public int PickedMVPId { get; set; }
        public int TimesPicked { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
