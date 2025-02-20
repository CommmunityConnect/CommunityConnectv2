using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using SQLite;
using Microsoft.EntityFrameworkCore;

public class IncidentReport
{

    [SQLite.PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string IncidentType { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string ImagePath { get; set; } // Path to uploaded image
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    public bool IsApproved { get; set; }  // Admin approval flag
    public bool IsDeclined { get; set; }  // True = Declined, False = Pending
}
