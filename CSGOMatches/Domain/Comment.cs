using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime Created { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
