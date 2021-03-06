﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarModelExt.Models;
using CarModelExt.Repository;
using CarModelExt.Repository.Interfaces;
using CarModelExt.BL;
using System.Net.Mail;
using CarModelExt.ViewModels;

namespace CarModelExt.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly IBussinessLogic _bussinessLogic;


        public CarModelsController()
        {
            _carModelRepository = new CarModelRepository();
            _bussinessLogic = new BussinessLogic();


        }
        // GET: CarModels
        public ActionResult Index()
        {
            var vmCars = new VMCars()
            {
                CarList = new List<CarModel>(),
                ShowIfAuth = _bussinessLogic.IsLogged()
            };

            if (vmCars.ShowIfAuth)
            {
               vmCars.CarList = _carModelRepository.GetWhere(x => x.Id >= 0);
            }
            else
            {
                vmCars.CarList = _carModelRepository.GetWhere(x => x.Id >= 0 && x.IsActive);
            }
            return View(vmCars);
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel CarModel = _carModelRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (CarModel == null)
            {
                return HttpNotFound();
            }
            return View(CarModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModel CarModel)
        {
            //var validator = new AddressValidator();
            //var result = validator.Validate(CarModel);

            if (ModelState.IsValid)
            {
                if(!_bussinessLogic.IsLogged())
                {
                    CarModel.DateCreate = DateTime.Now;
                    //var message = _mailService.CreateMailMessage(CarModel);

                    //_mailService.SendEmail(message);
                }
                CarModel.ModPerson = _bussinessLogic.GetUserName();
                CarModel.RecordAuthor = _bussinessLogic.GetUserName();
                _carModelRepository.Create(CarModel);
                return RedirectToAction("Index");
            }

            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError("", error.ErrorMessage);
            //}
            return View(CarModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarModel CarModel = _carModelRepository.GetWhere(x => x.Id == id).FirstOrDefault();
           
            if (CarModel == null)
            {
                return HttpNotFound();
            }
            return View(CarModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarModel CarModel)
        {
            if (ModelState.IsValid)
            {
                CarModel.ModPerson = _bussinessLogic.GetUserName();
                _carModelRepository.Edit(CarModel);
                return RedirectToAction("Index");
            }
            return View(CarModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel CarModel = _carModelRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (CarModel == null)
            {
                return HttpNotFound();
            }
            return View(CarModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel CarModel = _carModelRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _carModelRepository.Delete(CarModel);
            return RedirectToAction("Index");
        }
    }
}

