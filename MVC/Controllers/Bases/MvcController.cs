﻿using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MVC.Controllers.Bases
{
    public abstract class MvcController : Controller
    {
        public MvcController()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
