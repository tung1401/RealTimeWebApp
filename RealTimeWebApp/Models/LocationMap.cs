using System;
using System.Collections.Generic;

namespace RealTimeWebApp.Models
{
    public partial class LocationMap
    {
        public int LocationMapId { get; set; }
        public string LocationMapName { get; set; }
        public string LocationMapDescription { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationMapImageUrl { get; set; }
    }
}
