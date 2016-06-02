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

        // POST: api/Matches
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch(MatchCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vm.Match = new Match();
            

            var team1 = _uow.Teams.GetById(vm.TeamOneId);
            var team2 = _uow.Teams.GetById(vm.TeamTwoId);

            if (team1 == null || team2 == null)
            {
                return BadRequest();
            }
            vm.Match.TeamOneId = vm.TeamOneId;
            vm.Match.TeamTwoId = vm.TeamTwoId;

            _uow.Matches.Add(vm.Match);
            _uow.Commit();

            var gameMaps = new List<MapInMatch>();

            foreach (var mapId in vm.MapIds)
            {
                var map = _uow.Maps.GetById(mapId);
                if (map == null)
                {
                    return BadRequest();
                }

                gameMaps.Add(new MapInMatch() { MapId = mapId, MatchId = vm.Match.MatchId });

            }

            foreach (var map in gameMaps)
            {
                _uow.MapInMatches.Add(map);
            }

            _uow.Commit();

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

            return Ok(match);
        }

        //// PUT: api/Matches/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMatch(int id, Match match)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != match.MatchId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(match).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MatchExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Matches
        //[ResponseType(typeof(Match))]
        //public IHttpActionResult PostMatch(Match match)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Matches.Add(match);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = match.MatchId }, match);
        //}

        //// DELETE: api/Matches/5
        //[ResponseType(typeof(Match))]
        //public IHttpActionResult DeleteMatch(int id)
        //{
        //    Match match = db.Matches.Find(id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Matches.Remove(match);
        //    db.SaveChanges();

        //    return Ok(match);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MatchExists(int id)
        //{
        //    return db.Matches.Count(e => e.MatchId == id) > 0;
        //}
    }
}