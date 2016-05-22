using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MapInMatch
    {
        public int MapInMatchId { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int MapId { get; set; }
        public virtual Map Map { get; set; }
    }
}
