using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class FakePassengerRepository : IPassengerRepository
    {
        public IQueryable<Passenger> Pass =>
            new List<Passenger>
            {
                new Passenger(){PassengerId=10, Name="John", Surname="Cena", Email="crazy_boy795@hotmail.com", Phone="4542412", BirthDate= new DateOnly(1970,08,09)}
            }.AsQueryable();
        public IQueryable<Passenger> Passengers => throw new NotImplementedException();


        public void DeletePassenger(int id)
        {
            throw new NotImplementedException();
        }
        public Passenger getPassenger(int id)
        {
            throw new NotImplementedException();
        }
        public void registerPassenger(Passenger pas)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassengerInformation(Passenger pas)
        {
            throw new NotImplementedException();
        }
        public List<Passenger> ListAllPassengers()
        {
            throw new NotImplementedException();
        }
    }
}
