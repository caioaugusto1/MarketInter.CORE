using AutoMapper;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.App.AutoMapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<EnvironmentViewModel, Inter.Core.Domain.Entities.Environment>().ReverseMap();

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

            CreateMap<College, CollegeViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.Name, y => y.MapFrom(f => f.Name))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.City, y => y.MapFrom(f => f.City))
                .ForMember(x => x.Country, y => y.MapFrom(f => f.Country))
                .ForMember(x => x.CollegeTimeViewModel, y => y.MapFrom(f => f.Time))
                .ReverseMap();

            CreateMap<CollegeTime, CollegeTimeViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.Time, y => y.MapFrom(f => f.Time))
                .ForMember(x => x.TimeForWeek, y => y.MapFrom(f => f.TimeForWeek))
                .ForMember(x => x.Period, y => y.MapFrom(f => f.Period))
                .ForMember(x => x.College, y => y.MapFrom(f => f.College))
                .ReverseMap();

            CreateMap<Accomodation, AccomodationViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.Identifier, y => y.MapFrom(f => f.Identifier))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.ContactName, y => y.MapFrom(f => f.ContactName))
                .ForMember(x => x.ContactNumber, y => y.MapFrom(f => f.ContactNumber))
                .ForMember(x => x.NumberOfPlaces, y => y.MapFrom(f => f.NumberOfPlaces))
                .ReverseMap();
        }
    }
}
