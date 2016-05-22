using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MatchDTO
    {
        public int MatchId { get; set; }
        public string TeamOneName { get; set; }
        public string TeamTwoName { get; set; }
        public int TeamOnePercentage { get; set; }
        public int TeamTwoPercentage { get; set; }
        public List<MapDTO> Maps { get; set; }
    }
}
