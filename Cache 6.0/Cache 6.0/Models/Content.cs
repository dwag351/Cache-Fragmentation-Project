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
        [Required]
        public int ChunksLoaded { get; set; }
        [Required]
        public string Time { get; set; }
    }

    public class EventContent
    {
        [Key]
        public int ID { get; set; }
        public string Event { get; set; }
    }
}
