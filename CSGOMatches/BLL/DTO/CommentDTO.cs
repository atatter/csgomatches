using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime Created { get; set; }
    }
}
