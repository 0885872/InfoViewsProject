﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InfoViewsProject.Models;
using Newtonsoft.Json;

namespace InfoViewsProject.Controllers
{
    public class HomeController : Controller
    {
        //Reservaties ophalen
        [HttpGet]
        public ActionResult Index()
        {
            Database db = new Database();
            List<string[]> results = db.getReservations();
            var json = JsonConvert.SerializeObject(results);
            ViewData["results"] = json;
            return View();
        }

        //Reservaties posten
        [HttpPost]
        public ActionResult SetReservation([FromBody]ReservationModel reservation)
        {
            ReservationModel reservations = new ReservationModel
            {
                title = reservation.title,
                start = reservation.start,
                end = reservation.end

            };
            Database db = new Database();
            db.setReservations(reservations);
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}


    }
}
