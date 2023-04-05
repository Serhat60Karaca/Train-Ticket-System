using System;
using System.Collections.Generic;

namespace TicketApp.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Reservations = new HashSet<Reservation>();
            Classes = new HashSet<Class>();
        }

        public int ScheduleId { get; set; }
        public int TrainId { get; set; }
        public int RouteId { get; set; }
        public int ClassId { get; set; }
        public DateOnly DepartureTime { get; set; }
        public decimal Price { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Route Route { get; set; } = null!;
        public virtual Train Train { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
