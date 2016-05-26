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


        // GET: api/Matches
        public List<MapDTO> GetMaps()
        {
            var maps = _service.getAllMaps();
            return maps;
        }
    }
}
