using MyTrailer.Infrastructure;

namespace MyTrailer.Application.Services
{
    public class RentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public void CreateBooking(int trailerId, DateTime startDate, DateTime endDate)
        {
            // Business logic for booking a trailer
        }
    }
}
