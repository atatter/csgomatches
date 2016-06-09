using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class PlayerFactory
    {
        public PlayerDTO createBasicDTO(Player player)
        {
            return new PlayerDTO
            {
               PlayerId = player.PlayerId,
               Nick = player.Nick
            };
        }
    }
}
