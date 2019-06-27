using AutoMapper;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Presentation.Models.Identity;
using System;
using System.Globalization;

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
                //.ForMember(x => x.Advisors, y => y.MapFrom(f => f.AdvisorViewModel))
                .ReverseMap();

            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.CustomerId, y => y.MapFrom(f => f.CustomerId))
                .ForMember(x => x.EnviromentId, y => y.MapFrom(f => f.EnvironmentId))
                .ForMember(x => x.FullName, y => y.MapFrom(f => f.FullName))
                .ForMember(x => x.Email, y => y.MapFrom(f => f.Email))
                .ForMember(x => x.MobileNumber, y => y.MapFrom(f => f.MobileNumber))
                .ForMember(x => x.DateOfBirthday, y => y.MapFrom(f => f.DateOfBirthday))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.City, y => y.MapFrom(f => f.City))
                .ForMember(x => x.Country, y => y.MapFrom(f => f.Country))
                .ForMember(x => x.Nationality, y => y.MapFrom(f => f.Nationality))
                .ForMember(x => x.PassportNumber, y => y.MapFrom(f => f.PassaportNumber))
                .ReverseMap();

            CreateMap<CulturalExchangeFileUpload, CulturalExchangeFileUploadViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.FileName, y => y.MapFrom(f => f.FileName))
                .ForMember(x => x.Type, y => y.MapFrom(f => f.Type))
                .ForMember(x => x.UploadDate, y => y.MapFrom(f => f.UploadDate))
                .ForMember(x => x.CulturalExchangeId, y => y.MapFrom(f => f.CulturalExchangeId))
                .ForMember(x => x.CulturalExchangeViewModel, y => y.MapFrom(f => f.CulturalExchange))
                .ReverseMap();

            CreateMap<College, CollegeViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.EnviromentId, y => y.MapFrom(f => f.EnvironmentId))
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
                .ForMember(x => x.Price, y => y.MapFrom(f => Math.Round(f.Price, 2)))
                .ForMember(x => x.BookPrice, y => y.MapFrom(f => Math.Round(f.BookPrice, 2)))
                .ForMember(x => x.ExamPrice, y => y.MapFrom(f => Math.Round(f.ExamPrice, 2)))
                .ForMember(x => x.InsurancePrice, y => y.MapFrom(f => Math.Round(f.InsurancePrice, 2)))
                .ForMember(x => x.AccomodationPrice, y => y.MapFrom(f => Math.Round(f.AccomodationPrice, 2)))
                .ForMember(x => x.CollegeId, y => y.MapFrom(f => f.CollegeId))
                .ReverseMap();

            CreateMap<Accomodation, AccomodationViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
                .ForMember(x => x.Identifier, y => y.MapFrom(f => f.Identifier))
                .ForMember(x => x.Address, y => y.MapFrom(f => f.Address))
                .ForMember(x => x.ContactName, y => y.MapFrom(f => f.ContactName))
                .ForMember(x => x.ContactNumber, y => y.MapFrom(f => f.ContactNumber))
                .ForMember(x => x.NumberOfPlaces, y => y.MapFrom(f => f.NumberOfPlaces))
                .ForMember(x => x.EnviromentId, y => y.MapFrom(f => f.EnvironmentId))
                .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(f => f.Environment))
                .ForMember(x => x.CulturalExchangeViewModel, y => y.MapFrom(f => f.CulturalExchanges))

                .ReverseMap();

            CreateMap<CulturalExchange, CulturalExchangeViewModel>()
               .ForMember(x => x.Id, y => y.MapFrom(f => f.Id))
               .ForMember(x => x.StudentViewModel, y => y.MapFrom(f => f.Student))
               .ForMember(x => x.CollegeViewModel, y => y.MapFrom(f => f.College))
               .ForMember(x => x.AccomodationViewModel, y => y.MapFrom(f => f.Accomodation))
               .ForMember(x => x.CollegeTimeViewModel, y => y.MapFrom(f => f.CollegeTime))
               .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(f => f.Environment))
               .ForMember(x => x.CulturalExchangeFileUploadVM, y => y.MapFrom(f => f.CulturalExchangeFileUpload))
               .ForMember(x => x.INSUR, y => y.MapFrom(f => f.INSUR))
               .ForMember(x => x.ArrivalDateTime, y => y.MapFrom(f => f.ArrivalDateTime))
               .ForMember(x => x.StartDate, y => y.MapFrom(f => DateTime.Parse(f.StartDate.ToString(), new CultureInfo("pt-BR"))))
               .ForMember(x => x.Company, y => y.MapFrom(f => f.Company))
               .ForMember(x => x.FlightNumber, y => y.MapFrom(f => f.FlightNumber))
               .ForMember(x => x.CollegePayment, y => y.MapFrom(f => f.CollegePayment))
               .ForMember(x => x.QuantityDaysOfAccomodation, y => y.MapFrom(f => f.DaysOfAccomodation))
               .ForMember(x => x.SalesMan, y => y.MapFrom(f => f.SalesMen))
               .ForMember(x => x.TotalValue, y => y.MapFrom(f => f.TotalValue))
               .ReverseMap();

            CreateMap<ReceivePaymentCulturalExchange, ReceivePaymentCulturalExchangeViewModel>()
               .ForMember(x => x.Id, y => y.MapFrom(f => Convert.ToString(f.Id)))
               .ForMember(x => x.DateOfPayment, y => y.MapFrom(f => f.DateOfPayment))
               .ForMember(x => x.From, y => y.MapFrom(f => f.From))
               .ForMember(x => x.To, y => y.MapFrom(f => f.To))
               .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(f => f.Environment))
               .ForMember(x => x.CulturalExchangeId, y => y.MapFrom(f => f.CulturalExchangeId))
               .ForMember(x => x.EnviromentId, y => y.MapFrom(f => f.EnvironmentId))
               .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(f => f.Environment))
               .ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(x => x.EnvironmentViewModel, y => y.MapFrom(z => z.Environment))
                .ForMember(x => x.EnvironmentId, y => y.MapFrom(z => z.EnvironmentId))
                .ReverseMap();

        }
    }
}
