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
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace WebAPI.Controllers.api
{
    public class TeamsController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();
        private ITeamRepository _repo;

        public TeamsController()
        {
            _repo = new TeamRepository(db);
        }

        // GET api/values
        public List<Team> Get()
        {
            return _repo.All;
        }


    }
}