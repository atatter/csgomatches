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
    public class MatchService
    {
        private IMatchRepository _repo;
        private IMapRepository _mapRepo;
        private IMapInMatchRepository _mapInMatchRepo;
        private MatchFactory _factory;
        private MapFactory _factoryMap;

        public MatchService()
        {
            _mapRepo = new MapRepository(new DataBaseContext());
            _repo = new MatchRepository(new DataBaseContext());
            _mapInMatchRepo = new MapInMatchRepository(new DataBaseContext());
            _factory = new MatchFactory();
            _factoryMap = new MapFactory();
        }

        public List<MatchDTO> getAllMatches()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x, x.Maps.Select(t => _factoryMap.createBasicDTO(t.Map)).ToList())).ToList();
        }

        public MatchDTO getMatchById(int id)
        {
            var match = this._repo.All.Where(x => x.MatchId == id).FirstOrDefault();

            if (match != null)
            {
                return _factory.createBasicDTO(match, match.Maps.Select(t => _factoryMap.createBasicDTO(t.Map)).ToList());
            }
            else
            {
                return null;
            }
            
        }

        public bool addMatch(MatchAddDTO dto)
        {
            dto.Match = new Match();

            dto.Match.TeamOneId = dto.TeamOneId;
            dto.Match.TeamTwoId = dto.TeamTwoId;

            _repo.Add(dto.Match);
            _repo.SaveChanges();

            var gameMaps = new List<MapInMatch>();

            foreach (var mapId in dto.MapIds)
            {
                var map = _mapRepo.GetById(mapId);
                if (map == null)
                {
                    return false;
                }

                gameMaps.Add(new MapInMatch() { MapId = mapId, MatchId = dto.Match.MatchId });

            }

            foreach (var map in gameMaps)
            {
                _mapInMatchRepo.Add(map);
            }
            _mapInMatchRepo.SaveChanges();
            _repo.SaveChanges();
            return true;
        }

    }
}
