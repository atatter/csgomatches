using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MapAddEditViewModel
    {
        [MaxLength(128)]
        public string MapName { get; set; }
    }
}