using DigitalLeap.Repositories.EntityModel;

namespace DigitalLeap.Repositories
{
    public interface IEnquiryRepository : IEntityRepository<Domain.Model.ContactInformation, ContactInformation>
    {
    }
}