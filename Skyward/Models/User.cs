using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class User
    {
        public int Id { get; set; }
        public int HumenId { get; set; }
        public int RoleUserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Achievements { get; set; }
        public virtual Humen Humen { get; set; }
        public virtual RoleUser RoleUser { get; set; }
        public static User User_auth { get; set; }
    }
}
