using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Dtos
{
    public class ContentInputDto
    {
        public string Filename { get; set; }
        public int TotalChunks { get; set; }
        public string Data { get; set; }
    }
}
