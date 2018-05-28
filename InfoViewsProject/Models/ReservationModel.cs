using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InfoViewsProject.Models;
using Newtonsoft.Json;
using InfoViewsProject.Controllers;

namespace InfoViewsProject.Models
{

    public class ReservationModel
    {
        public JsonResult ReservationResults { get; set; }
    }
}