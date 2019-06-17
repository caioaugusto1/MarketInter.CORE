﻿using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, ReceivePaymentCulturalExchange")]
    public class ReceivePaymentCulturalExchangeController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReceivePaymentCulturalExchangeAppService _receivePaymentCulturalExchangeAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        private readonly ICollegeAppService _collegeAppService;

        public ReceivePaymentCulturalExchangeController(
            UserManager<ApplicationUser> userManager,
            IReceivePaymentCulturalExchangeAppService receivePaymentCulturalExchangeAppService,
            ICulturalExchangeAppService culturalExchangeAppService,
            ICollegeTimeAppService collegeTimeAppService,
            ICollegeAppService collegeAppService)
        {
            _userManager = userManager;
            _collegeTimeAppService = collegeTimeAppService;
            _collegeAppService = collegeAppService;
            _receivePaymentCulturalExchangeAppService = receivePaymentCulturalExchangeAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
        }

        // GET: ReceivePaymentCulturalExchange
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            var paymentsList = _receivePaymentCulturalExchangeAppService.GetAllIncludedDependency(user.EnvironmentId);

            return View(paymentsList);
        }

        // GET: ReceivePaymentCulturalExchange/Details/5
        public IActionResult Details(Guid id)
        {
            var receivePayments = _receivePaymentCulturalExchangeAppService.GetById(id);

            if (receivePayments == null)
                return NotFound();

            return View(receivePayments);
        }

        // GET: ReceivePaymentCulturalExchange/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.CulturalExchange = _culturalExchangeAppService.GetAll(user.EnvironmentId);

            return View();
        }

        // POST: ReceivePaymentCulturalExchange/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceivePaymentCulturalExchangeViewModel receivePaymentVM)
        {
            if (ModelState.IsValid)
            {
                receivePaymentVM = _receivePaymentCulturalExchangeAppService.Add(receivePaymentVM);

                if (!receivePaymentVM.ValidationResult.Any())
                    return RedirectToAction("Index", "ReceivePaymentCulturalExchange");
            }

            return View();
        }

        // GET: ReceivePaymentCulturalExchange/Edit/5
        public IActionResult Edit(Guid id)
        {
            var culturalExchangeViewModel = _receivePaymentCulturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        // POST: ReceivePaymentCulturalExchange/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ReceivePaymentCulturalExchangeViewModel paymentReceiveVM)
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _receivePaymentCulturalExchangeAppService.Update(user.EnvironmentId, paymentReceiveVM);

                return RedirectToAction("Details", "ReceivePaymentCulturalExchange");
            }

            return View(ModelState);
        }

        // GET: ReceivePaymentCulturalExchange/Delete/5
        public IActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: ReceivePaymentCulturalExchange/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}