using System;
using System.Collections.Generic;

namespace TicketApp.Models
{
    public partial class Class
    {
        public Class()
        {
            Schedules = new HashSet<Schedule>();
            SchedulesNavigation = new HashSet<Schedule>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Schedule> SchedulesNavigation { get; set; }
    }
}
