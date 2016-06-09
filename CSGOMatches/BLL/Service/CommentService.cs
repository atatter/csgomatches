using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class CommentService
    {
        private ICommentRepository _repo;
        private CommentFactory _factory;

        public CommentService()
        {
            _factory = new CommentFactory();
            _repo = new CommentRepository(new DataBaseContext());
        }

        public List<CommentDTO> getCommentsByMatchId(int id)
        {
            var item = _repo.All.Where(x => x.MatchId == id).ToList();
            if (item.Count > 0)
            {
                return item.Select(x => _factory.createBasicDTO(x)).ToList();
            }
            else
            {
                return null;
            }
                  
        }
    }
}
