using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using USM_Model;

namespace UberSportManager.Controllers
{
    public class PopulateController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public PopulateController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("api/[controller]")]
        public ActionResult Index()
        {
            if (UnitOfWork.PopulateDB())
                return Content("Done");
            else
                return Content("Fail");
        }
    }
}