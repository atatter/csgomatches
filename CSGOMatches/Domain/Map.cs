using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Map
    {
        public int MapId { get; set; }

        public string MapName { get; set; }

        public virtual List<MapInMatch> MapInMatches { get; set; }
    }
}
