using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL.Interfaces;
using Domain;
using WebAPI.Models;

namespace WebAPI.Controllers.api
{
    public class VotesController : ApiController
    {
        private readonly MatchService _service;
        private readonly IUOW _uow;


        public VotesController(IUOW uow)
        {
            _uow = uow;
            _service = new MatchService();
        }



        // POST: api/Votes
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch(MatchVoteViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = _uow.Matches.GetById(vm.MatchId);

            if (match == null)
            {
                return BadRequest(ModelState);
            }

            if (vm.VoteForTeamOne)
            {
                match.TeamOneVotes = match.TeamOneVotes + 1;
            }
            else if (vm.VoteForTeamTwo)
            {
                match.TeamTwoVotes = match.TeamTwoVotes + 1;
            }

            _uow.Matches.Update(match);
            _uow.Commit();

            return Ok("Done");
        }
    }
}
