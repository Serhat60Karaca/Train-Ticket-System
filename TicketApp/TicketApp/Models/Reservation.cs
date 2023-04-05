using System;
using System.Collections.Generic;

namespace TicketApp.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? ScheduleId { get; set; }
        public int? PassengerId { get; set; }
        public int? NumTickets { get; set; }

        public virtual Passenger? Passenger { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
