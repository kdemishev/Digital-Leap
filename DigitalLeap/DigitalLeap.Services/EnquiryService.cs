using DigitalLeap.Domain.Model;
using DigitalLeap.Repositories;

namespace DigitalLeap.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryRepository _repository;

        public EnquiryService(IEnquiryRepository repository)
        {
            _repository = repository;
        }
        public void Save(ContactInformation contactInformation)
        {
            _repository.Save(contactInformation);
        }
    }
}