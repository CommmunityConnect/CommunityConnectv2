using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CommunityConnect.model
{
    public class Admin
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Username { get; set; }
        public string Password { get; set; }  
    }
}
