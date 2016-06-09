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
    public class PlayersController : ApiController
    {

        private readonly IUOW _uow;
        private readonly PlayerService _service;

        public PlayersController(IUOW uow)
        {
            _uow = uow;
            _service = new PlayerService();
        }

        // GET: api/Players
        public List<PlayerDTO> Get()
        {
            return _service.getAllPlayers();
        }

        // GET: api/Players/5
        public string Get(int id)
        {
            return "value";
        }
        [Authorize]
        // POST: api/Players
        public IHttpActionResult Post(PlayerAddEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Players.Add(new Player { Nick = vm.Nick });
            _uow.Commit();

            return Ok();
        }
        [Authorize]
        // PUT: api/Players/5
        public IHttpActionResult Put(int id, PlayerAddEditViewModel vm)
        {
            var player = _uow.Players.GetById(id);
            if (player == null)
            {
                return BadRequest();
            }
            player.Nick = vm.Nick;
            _uow.Players.Update(player);
            _uow.Commit();

            return Ok();
        }
        [Authorize]
        // DELETE: api/Players/5
        public IHttpActionResult Delete(int id)
        {
            if (_uow.Players.GetById(id) == null)
            {
                return BadRequest();
            }

            _uow.Players.Delete(id);
            _uow.Commit();

            return Ok();
        }
    }
}
