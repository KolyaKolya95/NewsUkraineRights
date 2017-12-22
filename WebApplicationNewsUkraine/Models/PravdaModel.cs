using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplicationNewsUkraine.Models
{
    public class PravdaModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
    }
}