using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private TicketsContext _ticketsContext;
        public PassengerRepository(TicketsContext ticketsContext)
        {
            _ticketsContext = ticketsContext;
        }

        public IQueryable<Passenger> Passengers => _ticketsContext.Passengers;


        public void registerPassenger(Passenger pas)
        {
            _ticketsContext.Passengers.Add(pas);
            _ticketsContext.SaveChanges();
        }
        public Passenger getPassenger(int id)
        {
            return _ticketsContext.Passengers.FirstOrDefault(i=>i.PassengerId == id);
        }
        public void UpdatePassengerInformation(Passenger pas)
        {
            _ticketsContext.Passengers.Update(pas);
            _ticketsContext.SaveChanges();
        }
        public void DeletePassenger(int id)
        {
            var passenger = getPassenger(id);

            if(passenger != null)
            {
                _ticketsContext.Passengers.Remove(passenger);
                _ticketsContext.SaveChanges();
            }
        }
        public List<Passenger> ListAllPassengers()
        {
            return _ticketsContext.Passengers.ToList();
        }

        
    }
}
