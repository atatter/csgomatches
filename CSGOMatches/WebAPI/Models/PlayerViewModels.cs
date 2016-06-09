using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PlayerAddEditViewModel
    {
        [MaxLength(128)]
        public string Nick { get; set; }
    }
}