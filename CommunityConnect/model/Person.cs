using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityConnect.model
{
    public class Person
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string LastSeenLocation { get; set; }
        public string CaseDetails { get; set; }
        public string DateLastSeen {  get; set; }
        public string WantedFor {  get; set; }
        public int Age {  get; set; }
        public string Photo {  get; set; }
    }
}
