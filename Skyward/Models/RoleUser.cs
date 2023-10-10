using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class RoleUser
    {
        public int Id { get; set; }
        public string Role_user { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
