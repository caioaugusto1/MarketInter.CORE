using AutoMapper;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;

namespace Inter.Core.App.AutoMapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<EnvironmentViewModel, SystemEnvironment>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(f => f.CompanyName))
                .ForMember(x => x.CompanyCode, y => y.MapFrom(f => f.CustomerCode))
                .ForMember(x => x.StartDate, y => y.MapFrom(f => f.StartDate))
                .ForMember(x => x.FinishDate, y => y.MapFrom(f => f.FinishDate))
                .ForMember(x => x.Available, y => y.MapFrom(f => f.Avaliable))
                .ForMember(x => x.Students, y => y.MapFrom(f => f.StudentViewModel))
                .ForMember(x => x.Users, y => y.MapFrom(f => f.ApplicationUserViewModel))
                .ForMember(x => x.Accomodations, y => y.MapFrom(f => f.AccomodationViewModel))
                .ForMember(x => x.Colleges, y => y.MapFrom(f => f.CollegeViewModel))
                .ForMember(x => x.CulturalExchange, y => y.MapFrom(f => f.CulturalExchangeViewModel))
                .ForMember(x => x.Advisors, y => y.MapFrom(f => f.AdvisorViewModel))
                .ReverseMap();

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
                .ForMember(x => x.CollegeTimeViewModel, y => y.MapFrom(f => f.CollegeTime))
                .ReverseMap();

            CreateMap<CollegeTime, CollegeTimeViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.StartTime, y => y.MapFrom(f => f.StartTime))
                .ForMember(x => x.FinishTime, y => y.MapFrom(f => f.FinishTime))
                .ForMember(x => x.DaysOfWeek, y => y.MapFrom(f => f.DaysOfWeek))
                .ForMember(x => x.TimeForWeek, y => y.MapFrom(f => f.TimeForWeek))
                .ForMember(x => x.Period, y => y.MapFrom(f => f.Period))
                .ForMember(x => x.Price, y => y.MapFrom(f => f.Price))
                .ForMember(x => x.BookPrice, y => y.MapFrom(f => f.BookPrice))
                .ForMember(x => x.ExamPrice, y => y.MapFrom(f => f.ExamPrice))
                .ForMember(x => x.InsurancePrice, y => y.MapFrom(f => f.InsurancePrice))
                .ForMember(x => x.BookPrice, y => y.MapFrom(f => f.BookPrice))
                .ForMember(x => x.AccomodationPrice, y => y.MapFrom(f => f.AccomodationPrice))
                .ForMember(x => x.CollegeId, y => y.MapFrom(f => f.CollegeId))
                .ReverseMap();

            CreateMap<Accomodation, AccomodationViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.Identifier, y => y.MapFrom(f => f.Identifier))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.ContactName, y => y.MapFrom(f => f.ContactName))
                .ForMember(x => x.ContactNumber, y => y.MapFrom(f => f.ContactNumber))
                .ForMember(x => x.NumberOfPlaces, y => y.MapFrom(f => f.NumberOfPlaces))
                .ReverseMap();

            CreateMap<CulturalExchange, CulturalExchangeViewModel>()
               .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
               .ForMember(x => x.StudentViewModel, y => y.MapFrom(f => f.Student))
               .ForMember(x => x.CollegeViewModel, y => y.MapFrom(f => f.College))
               .ForMember(x => x.AccomodationViewModel, y => y.MapFrom(f => f.Accomodation))
               .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(f => f.Environment))
               .ForMember(x => x.INSUR, y => y.MapFrom(f => f.INSUR))
               .ForMember(x => x.ArrivalDateTime, y => y.MapFrom(f => f.Arrival))
               .ForMember(x => x.StartDate, y => y.MapFrom(f => f.StartDate))
               .ForMember(x => x.Company, y => y.MapFrom(f => f.Company))
               .ForMember(x => x.FlightNumber, y => y.MapFrom(f => f.FlightNumber))
               .ForMember(x => x.CollegePayment, y => y.MapFrom(f => f.CollegePayment))
               .ForMember(x => x.QuantityDaysOfAccomodation, y => y.MapFrom(f => f.DateOfAccomodation))
               .ForMember(x => x.TotalValue, y => y.MapFrom(f => f.TotalValue))
               .ReverseMap();
        }
    }
}
