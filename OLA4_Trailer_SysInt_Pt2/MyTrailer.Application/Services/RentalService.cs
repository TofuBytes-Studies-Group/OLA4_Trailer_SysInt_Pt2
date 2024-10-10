using MyTrailer.Domain.Aggregates;
using MyTrailer.Domain.ValueObjects;
using MyTrailer.Infrastructure;

namespace MyTrailer.Application.Services
{
    public class RentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ITrailerRepository _trailerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly PaymentService _paymentService;

        public RentalService(IRentalRepository rentalRepository, ITrailerRepository trailerRepository,
            ICustomerRepository customerRepository, PaymentService paymentService)
        {
            _rentalRepository = rentalRepository;
            _trailerRepository = trailerRepository;
            _customerRepository = customerRepository;
            _paymentService = paymentService;
        }

        public async Task<Rental> CreateRental(int customerId, int trailerId, DateTime startDate, DateTime endDate, bool isInsured)
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

            var price = await _paymentService.FetchInsurancePrice(isInsured);
            var rental = new Rental(customer, trailer, new Price(price), startDate, endDate, isInsured);
            

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