using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TypeTicketId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DateOfDelay { get; set; }
        public virtual TypeTicket TypeTicket { get; set; }
        public virtual List<Humen> Humens { get; set; } 
    }
}
