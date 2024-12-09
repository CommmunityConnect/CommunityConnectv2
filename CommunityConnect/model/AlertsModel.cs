using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityConnect.model
{
   public class Incident
    {
        public string Title { get; set; } = string.Empty; // Initialized with default value
        public string Severity { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
