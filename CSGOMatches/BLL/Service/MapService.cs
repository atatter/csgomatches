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
    public class MapService
    {
        private IMapRepository _repo;
        private MapFactory _factoryMap;

        public MapService()
        {
            _repo = new MapRepository(new DataBaseContext());
            _factoryMap = new MapFactory();
        }

        public List<MapDTO> getAllMaps()
        {
            return this._repo.All.Select(x => _factoryMap.createBasicDTO(x)).ToList();
        }
    }
}
