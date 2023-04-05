using System;
using System.Collections.Generic;

namespace TicketApp.Models
{
    public partial class Route
    {
        public Route()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int RouteId { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public int Distance { get; set; }

        public virtual Station? Destination { get; set; }
        public virtual Station? Origin { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
