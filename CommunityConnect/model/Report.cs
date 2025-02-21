using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityConnect.model
{
    public class Report
    {
        public string IncidentType { get; set; } // Type of incident (e.g., Fire, Accident)
        public string Description { get; set; } // Incident details
        public string Location { get; set; } // Where the incident occurred
        public string ImageUrl { get; set; } // Image path or URL
    }
}
