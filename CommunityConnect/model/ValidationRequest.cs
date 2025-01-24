using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityConnect.model
{
    public class ValidationRequest
    {
        public string IncidentType { get; set; }
        public string Location { get; set; }
        public string ReporterEmail { get; set; }
        public string ImageUrl { get; set; } // for displaying images
    }
}
