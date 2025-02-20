using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CommunityConnect.model
{
    public class Alert
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime AlertDate { get; set; } = DateTime.UtcNow;
    }
}
