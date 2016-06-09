using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Service;
using DAL.Interfaces;
using Domain;
using WebAPI.Models;

namespace WebAPI.Controllers.api
{
    public class MapsController : ApiController
    {
        private readonly MapService _service;
        private readonly IUOW _uow;


        public MapsController(IUOW uow)
        {
            _uow = uow;
            _service = new MapService();
        }


        // GET: api/Maps
        public List<MapDTO> GetMaps()
        {
            var maps = _service.getAllMaps();
            return maps;
        }
        [Authorize]
        // POST: api/Maps
        public IHttpActionResult Post(MapAddEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Maps.Add(new Map { MapName = vm.MapName });
            _uow.Commit();

            return Ok();
        }
        [Authorize]
        // PUT: api/Maps/5
        public IHttpActionResult Put(int id, MapAddEditViewModel vm)
        {
            var map = _uow.Maps.GetById(id);
            if (map == null)
            {
                return BadRequest();
            }
            map.MapName = vm.MapName;
            _uow.Maps.Update(map);
            _uow.Commit();

            return Ok();
        }
        [Authorize]
        // DELETE: api/Maps/5
        public IHttpActionResult Delete(int id)
        {
            if (_uow.Maps.GetById(id) == null)
            {
                return BadRequest();
            }

            _uow.Maps.Delete(id);
            _uow.Commit();

            return Ok();
        }
    }
}
