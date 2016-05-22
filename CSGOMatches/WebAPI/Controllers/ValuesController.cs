using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace WebAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        private DataBaseContext db = new DataBaseContext();
        private ITeamRepository _repo;

        public ValuesController()
        {
           _repo = new TeamRepository(db);
        }

        // GET api/values
        public List<Team> Get()
        {
            return _repo.All;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
