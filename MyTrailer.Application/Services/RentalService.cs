using MyTrailer.Domain.Aggregates;
using MyTrailer.Infrastructure;

namespace MyTrailer.Application.Services
{
    public class RentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ITrailerRepository _trailerRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService(IRentalRepository rentalRepository, ITrailerRepository trailerRepository,
            ICustomerRepository customerRepository)
        {
            _rentalRepository = rentalRepository;
            _trailerRepository = trailerRepository;
            _customerRepository = customerRepository;
        }

        public Rental CreateRental(int customerId, int trailerId, DateTime startDate, DateTime endDate, bool isInsured)
        {
            var trailer = _trailerRepository.GetById(trailerId);
            if (trailer == null || trailer.IsRented)
            {
                throw new InvalidOperationException("The selected trailer is not available.");
            }


            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }


            if (startDate >= endDate)
            {
                throw new ArgumentException("Start date must be earlier than end date.");
            }


            var rental = Rental.Create(customer, trailer, startDate, endDate, isInsured);
            rental.CalculatePrice();


            _rentalRepository.Add(rental);
            _rentalRepository.SaveChanges();

            return rental;
        }

        public Rental GetRentalById(int id)
        {
            var rental = _rentalRepository.GetById(id);
            if (rental == null)
            {
                throw new InvalidOperationException($"Rental with ID {id} not found.");
            }

            return rental;
        }

        public IEnumerable<Rental> GetRentalsByCustomerId(int customerId)
        {
            return _rentalRepository.GetRentalsByCustomerId(customerId);
        }
    }
}