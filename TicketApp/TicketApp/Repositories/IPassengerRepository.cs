using TicketApp.Models;

namespace TicketApp.Repositories
{
    public interface IPassengerRepository
    {
        IQueryable<Passenger> Passengers { get; }
        void registerPassenger(Passenger pas);
        Passenger getPassenger(int id);
        void UpdatePassengerInformation(Passenger pas);
        void DeletePassenger(int id);
        List<Passenger> ListAllPassengers();
    }
}
