﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UberSportManager.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}