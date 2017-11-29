using AutoMapper;
using DigitalLeap.Repositories.EntityModel;

namespace DigitalLeap.Web.MappingProfiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Domain.Model.ContactInformation, ContactInformation>().ReverseMap();
        }
    }
}