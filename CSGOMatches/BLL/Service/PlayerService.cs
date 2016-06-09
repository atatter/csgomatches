using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class PlayerService
    {
        private IPlayerRepository _repo;
        private PlayerFactory _factory;

        public PlayerService()
        {
            _repo = new PlayerRepository(new DataBaseContext());
            _factory = new PlayerFactory();
        }

        public List<PlayerDTO> getAllPlayers()
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
    }
}
