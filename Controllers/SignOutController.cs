﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahad_Project.Controllers
{
    public class SignOutController : Controller
    {
        public IActionResult SignOut()
        {
            return View();
        }
    }
}
