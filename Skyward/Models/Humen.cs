using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class Humen
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Male { get; set; }
        public int? TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual List<ScheduleHumen> ScheduleHumens { get; set; }
        public virtual List<User> Users { get; set; }
        public static Humen? Humen_change { get; set; }
    }
}
