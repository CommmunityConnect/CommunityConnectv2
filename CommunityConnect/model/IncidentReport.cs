using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityConnect.model
{
    public class IncidentReport
    {
        public string Id { get; set; }  
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool IsApproved { get; set; }
        public string IncidentType { get; internal set; }

         
    }

}