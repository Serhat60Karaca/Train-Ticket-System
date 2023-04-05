using System;
using System.Collections.Generic;

namespace TicketApp.Models
{
    public partial class Train
    {
        public Train()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int TrainId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
