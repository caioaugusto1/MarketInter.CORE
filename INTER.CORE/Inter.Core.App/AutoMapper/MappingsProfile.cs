using AutoMapper;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;

namespace Inter.Core.App.AutoMapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.CustomerId, y => y.MapFrom(f => f.CustomerId))
                .ForMember(x => x.FullName, y => y.MapFrom(f => f.FullName))
                .ForMember(x => x.Email, y => y.MapFrom(f => f.Email))
                .ForMember(x => x.MobileNumber, y => y.MapFrom(f => f.MobileNumber))
                .ForMember(x => x.DateOfBirthday, y => y.MapFrom(f => f.DateOfBirthday))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.City, y => y.MapFrom(f => f.City))
                .ForMember(x => x.Country, y => y.MapFrom(f => f.Country))
                .ForMember(x => x.Nationality, y => y.MapFrom(f => f.Nationality))
                .ForMember(x => x.PassaportNumber, y => y.MapFrom(f => f.PassaportNumber))
                .ReverseMap();


            CreateMap<EnvironmentViewModel, Inter.Core.Domain.Entities.Environment>().ReverseMap();
        }
    }
}
