using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class TypeTicket
    {
        public int Id { get; set; }
        public string? type_ticket { get; set; }
        public decimal? price { get; set; }
        public virtual List<Ticket> Tickets { get; set; } 
    }
}
