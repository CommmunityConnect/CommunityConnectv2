using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityConnect.model;
internal class UserProfileModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique]
    public string Username { get; set; }

    public string Password { get; set; }

    public string UserType { get; set; }  // "User" or "Admin"
}
