using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;

namespace WebAPI.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IUOW _uow;

        public TeamsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Teams
        public ActionResult Index()
        {
            return View(_uow.Teams.All);
        }

      
    }
}
