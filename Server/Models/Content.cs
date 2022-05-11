using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Content
    {
        [Key]
        public string Filename { get; set; }
        [Required]
        public int TotalChunks { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
