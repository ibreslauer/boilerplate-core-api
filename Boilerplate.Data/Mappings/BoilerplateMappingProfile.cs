using AutoMapper;
using Boilerplate.Common.Models;
using Boilerplate.Data.Models;

namespace Boilerplate.Data.Mappings
{
    public class BoilerplateMappingProfile : Profile
    {
        public BoilerplateMappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<UserToken, TokenModel>().ReverseMap();
        }
    }
}
