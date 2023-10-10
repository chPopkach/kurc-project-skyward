using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
        public string WorkDays { get; set; }
        public virtual List<ScheduleHumen> ScheduleHumens { get; set; }
    }
}
