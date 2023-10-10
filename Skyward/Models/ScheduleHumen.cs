using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class ScheduleHumen
    {
        public int Id { get; set; }
        public int HumenId { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Humen Humen { get; set; }
    }
}
