using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int[] PlayerIds { get; set; }
        public List<string> PlayerList { get; set; }
    }
}
