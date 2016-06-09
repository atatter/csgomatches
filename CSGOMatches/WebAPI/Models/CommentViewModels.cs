using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CommentPostViewModel
    {
        public int MatchId { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string CommentText { get; set; }
    }
}