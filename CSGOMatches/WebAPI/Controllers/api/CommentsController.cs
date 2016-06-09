using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Service;
using DAL.Interfaces;
using Domain;
using WebAPI.Models;

namespace WebAPI.Controllers.api
{
    public class CommentsController : ApiController
    {
        private readonly IUOW _uow;
        private readonly CommentService _service;

        public CommentsController(IUOW uow)
        {
            _uow = uow;
            _service = new CommentService();
        }

        // GET: api/Comments
        public List<Comment> Get()
        {
            return _uow.Comments.All;
        }
        
        // GET: api/Comments/5
        public IHttpActionResult Get(int id)
        {
            List<Comment> comments = _uow.Comments.All.Where(x => x.MatchId == id).ToList();

            if (comments.Count <= 0)
            {
                return NotFound();
            }

            return Ok(_service.getCommentsByMatchId(id));
        }
        // POST: api/Comments
        public IHttpActionResult Post(CommentPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comment comment = new Comment
            {
                CommentText = vm.CommentText,
                Name = vm.Name,
                MatchId = vm.MatchId,
                Created = DateTime.Now
            };

            _uow.Comments.Add(comment);
            _uow.Commit();

            return Ok();
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [Authorize]
        // DELETE: api/Comments/5
        public IHttpActionResult Delete(int id)
        {
            if (_uow.Comments.GetById(id) == null)
            {
                return NotFound();
            }

            _uow.Comments.Delete(id);
            _uow.Commit();

            return Ok();
        }
    }
}
