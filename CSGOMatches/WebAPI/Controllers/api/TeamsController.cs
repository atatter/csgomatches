using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using WebAPI.Models;

namespace WebAPI.Controllers.api
{
    public class TeamsController : ApiController
    {
        private ITeamRepository _repo;
        private TeamService _service;

        public TeamsController()
        {
            _repo = new TeamRepository(new DataBaseContext());
            _service = new TeamService();
        }

        // GET api/values
        public List<TeamDTO> Get()
        {
            return _service.getTeams();
        }

        // GET: api/Teams/5
        public IHttpActionResult Get(int id)
        {
            var query = _service.getTeamById(id);
            if (query == null)
            {
                return BadRequest();
            }
            return Ok(query);
        }
        [Authorize]
        // POST: api/Players
        public IHttpActionResult Post(TeamAddViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var status = _service.addTeam(vm.Name, vm.PlayerIds);
            if (!status)
            {
                return BadRequest();
            }

            return Ok();
        }
        [Authorize]
        // PUT: api/Players/5
        public IHttpActionResult Put(int id, TeamAddViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = _service.editTeam(vm.Name, vm.PlayerIds, id);

            if (!query)
            {
                return BadRequest();
            }

            return Ok();
        }
        [Authorize]
        // DELETE: api/Players/5
        public IHttpActionResult Delete(int id)
        {
            var team = _repo.GetById(id);
            if (team == null)
            {
                return BadRequest();
            }

            _repo.Delete(id);
            _repo.SaveChanges();

            return Ok();
        }


    }
}