using AutoMapper;

namespace DigitalLeap.Repositories
{
    public class EnquiryRepository : EntityRepository<Domain.Model.ContactInformation, EntityModel.ContactInformation>,
        IEnquiryRepository
    {
        public EnquiryRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }

}