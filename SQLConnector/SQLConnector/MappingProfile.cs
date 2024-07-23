using AutoMapper;
using SQLConnectorExtra;

namespace SQLConnector
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseModel>()
                       .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            // Map Address to AddressResponseModel
            CreateMap<Address, AddressResponseModel>();
        }
    }
}
