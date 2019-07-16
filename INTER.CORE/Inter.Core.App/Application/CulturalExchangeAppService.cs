using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.JsonModels;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Inter.Core.App.Application
{
    public class CulturalExchangeAppService : ICulturalExchangeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICulturalExchangeService _culturalExchangeService;
        private readonly IEnvironmentService _environmentService;

        public CulturalExchangeAppService(IMapper mapper, ICulturalExchangeService culturalExchangeService, IEnvironmentService environmentService)
        {
            _mapper = mapper;
            _culturalExchangeService = culturalExchangeService;
            _environmentService = environmentService;
        }

        public CulturalExchangeViewModel Add(Guid idEnvironment, CulturalExchangeViewModel culturalExchangeView)
        {
            var culturalExchange = _mapper.Map<CulturalExchange>(culturalExchangeView);
            culturalExchange.Environment = _mapper.Map<SystemEnvironment>(_environmentService.GetById(idEnvironment));

            if (!culturalExchangeView.HaveFlyTicket)
            {
                culturalExchangeView.FlightNumber = null;
                culturalExchangeView.Company = null;
                culturalExchange.StartAccomodation = null;
                culturalExchange.FinishAccomodation = null;
            }

            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.Add(culturalExchange));
        }

        public List<CulturalExchangeViewModel> GetAllPaymentFinished(Guid idEnvironment)
        {
            return _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAllPaymentFinished(idEnvironment));
        }

        public List<CulturalExchangeViewModel> GetAll(Guid idEnvironment, bool active)
        {
            return _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAll(idEnvironment, active));
        }

        public List<CulturalExchangeViewModel> GetAllByFilter(Guid idEnvironment, string startArrivalDate, string finishArrivalDate, string startDate, string startDateFinish, Guid collegeId, Guid accomodationId)
        {
            DateTime arrivalStart = DateTime.MinValue;
            DateTime arrivalFinish = DateTime.MinValue;
            DateTime courseStartDate = DateTime.MinValue;
            DateTime courseStartDateFinish = DateTime.MinValue;

            if (!string.IsNullOrWhiteSpace(startArrivalDate))
                arrivalStart = Convert.ToDateTime(DateTime.Parse(startArrivalDate, new CultureInfo("pt-BR")));

            if (!string.IsNullOrWhiteSpace(finishArrivalDate))
                arrivalFinish = Convert.ToDateTime(DateTime.Parse(finishArrivalDate, new CultureInfo("pt-BR")));

            if (!string.IsNullOrWhiteSpace(startDate))
                courseStartDate = Convert.ToDateTime(DateTime.Parse(startDate, new CultureInfo("pt-BR")));

            if (!string.IsNullOrWhiteSpace(startDateFinish))
                courseStartDateFinish = Convert.ToDateTime(DateTime.Parse(startDateFinish, new CultureInfo("pt-BR")));

            return _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAllByFilter(
                idEnvironment,
                arrivalStart, arrivalFinish,
                courseStartDate, courseStartDateFinish,
                collegeId, accomodationId));
        }

        public CulturalExchangeViewModel GetById(Guid id)
        {
            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.GetById(id));
        }

        public CulturalExchangeViewModel Inactive(Guid id)
        {
            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.Inactive(id));
        }

        public CulturalExchangeViewModel Update(Guid idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel)
        {
            var entity = _mapper.Map<CulturalExchange>(culturalExchangeViewModel);

            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.Update(idEnvironment, entity));
        }

        public CulturalExchangeViewModel UpdateDateStartAndFinish(Guid id, DateTime start, DateTime finish)
        {
            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.UpdateDateStartAndFinish(id, start, finish));
        }

        public HomeDashoboardInfoJson GetAllLast12Month(Guid idEnvironment)
        {
            HomeDashoboardInfoJson dashboard = new HomeDashoboardInfoJson();

            List<HomeDashoboardInfoJson.CulturalExchangePerMonthToShowGraphics> infoPerMonth = new List<HomeDashoboardInfoJson.CulturalExchangePerMonthToShowGraphics>();

            var culturalExchange = _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAllLast12Month(idEnvironment))
                .OrderBy(x => x.SaleDate);

            for (int i = 1; i <= 12; i++)
            {
                dashboard.TotalPerMonth.Add(new HomeDashoboardInfoJson.CulturalExchangePerMonthToShowGraphics
                {
                    CulturalExchangeTotal = culturalExchange.Where(x => x.SaleDate == DateTime.Now.AddMonths(-i)).Count(),
                    Year = Convert.ToString(DateTime.Now.AddMonths(-i).Year),
                    Month = Convert.ToString(DateTime.Now.AddMonths(-i).ToString("MM")),
                    MonthName = DateTime.Now.AddMonths(-i).ToString("MMM", CultureInfo.InvariantCulture)
                });
            }

            dashboard.TotalThisMonth.Total = _culturalExchangeService.GetAll(idEnvironment, true)
                .Where(x => x.SaleDate >= DateTime.Now.AddMonths(-1)).Count();

            return dashboard;
        }
    }
}
