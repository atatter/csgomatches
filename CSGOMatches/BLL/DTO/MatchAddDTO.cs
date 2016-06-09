using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class MatchAddDTO
    {
        public Match Match { get; set; }
        public int TeamOneId { get; set; }
        public int TeamTwoId { get; set; }
        public int[] MapIds { get; set; }
    }
}
