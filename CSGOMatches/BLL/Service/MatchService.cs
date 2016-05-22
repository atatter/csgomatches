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

namespace BLL.Service
{
    public class MatchService
    {
        private IMatchRepository _repo;
        private MatchFactory _factory;
        private MapFactory _factoryMap;

        public MatchService()
        {
            _repo = new MatchRepository(new DataBaseContext());
            _factory = new MatchFactory();
            _factoryMap = new MapFactory();
        }

        public List<MatchDTO> getAllMatches()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x, x.Maps.Select(t => _factoryMap.createBasicDTO(t.Map)).ToList())).ToList();
        }
    }
}
