using AutoMapper;
using Task1.BLL.Dto;
using Task1.DAL.Entities;

namespace Task1.BLL.Mapping;

public class DataMappingProfile : Profile
{
    public DataMappingProfile()
    {
        CreateMap<Dictionary<int, string>, Data>()
            .ForMember(
                dest => dest.Code,
                opt => opt.MapFrom(src => src.Keys.First())
            )
            .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom(src => src.Values.First())
            )
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Data, GetDataResponse>().ReverseMap();
    }
}