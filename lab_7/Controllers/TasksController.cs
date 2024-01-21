using lab_7.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_7.Controllers
{
    public class TasksController : Controller
    {
        private ADOModelDB db = new ADOModelDB();
        //2.1
        public ActionResult Index2_1(SearchModelForTask2_1 searchModel)
        {
            var data = from r in db.Real_estate_objects
                       join d in db.Districts on r.District equals d.District_id
                       where (string.IsNullOrEmpty(searchModel.DistrictName) || d.District_name.Contains(searchModel.DistrictName))
                       && (!searchModel.MinCost.HasValue || r.Cost >= searchModel.MinCost)
                       && (!searchModel.MaxCost.HasValue || r.Cost <= searchModel.MaxCost)
                       orderby r.Cost descending
                       select new ModelForTask2_1
                       {
                           Address = r.Address,
                           Area = r.Area,
                           Floor = r.Floor
                       };

            return View(data.ToList());
        }
    }
}