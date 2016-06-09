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
    public class MatchesController : ApiController
    {
        private readonly MatchService _service;
        private readonly IUOW _uow;


        public MatchesController(IUOW uow)
        {
            _uow = uow;
            _service = new MatchService();
        }


        // GET: api/Matches
        public List<MatchDTO> GetMatches()
        {
            return _service.getAllMatches();
        }
        [Authorize]
        // POST: api/Matches
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch(MatchAddDTO vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_uow.Teams.GetById(vm.TeamOneId) == null || _uow.Teams.GetById(vm.TeamTwoId) == null)
            {
                return BadRequest();
            }

            var answer = _service.addMatch(vm);

            if (answer == false)
            {
                return BadRequest();
            }
            

            return Ok("Done");
        }

        // GET: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = _uow.Matches.GetById(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(_service.getMatchById(id));
        }

        [Authorize]
        // DELETE: api/Matches/5
        public IHttpActionResult Delete(int id)
        {
            if (_uow.Matches.GetById(id) == null)
            {
                return NotFound();
            }

            _uow.Matches.Delete(id);
            _uow.Commit();

            return Ok();
        }

    }
}