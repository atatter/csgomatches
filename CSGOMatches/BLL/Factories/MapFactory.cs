using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class MapFactory
    {
        public MapDTO createBasicDTO(Map map)
        {
            return new MapDTO {
                MapId = map.MapId,
                MapName = map.MapName
            };
        }
    }
}
