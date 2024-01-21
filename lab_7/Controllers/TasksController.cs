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

        //2.2
        public ActionResult Index2_2(SearchModelForTask2_2 searchModel)
        {
            var data = from s in db.Sale
                       join r in db.Real_estate_objects on s.Object_id equals r.Object_id
                       join re in db.Realtor on s.Realtor_id equals re.Realtor_id
                       where r.Number_of_rooms == searchModel.Number_of_rooms
                       select new ModelForTask2_2
                       {
                           LastName = re.Last_name,
                           FirstName = re.First_name,
                           MiddleName = re.Middle_name
                       };

            return View(data.ToList());
        }

        //2.3
        public ActionResult Index2_3(SearchModelForTask2_3 searchModel)
        {
            var data = from r in db.Real_estate_objects
                       join s in db.Sale on r.Object_id equals s.Object_id
                       join re in db.Realtor on s.Realtor_id equals re.Realtor_id
                       where r.Floor == searchModel.Floor
                       select new ModelForTask2_3
                       {
                           Address = r.Address,
                           Area = r.Cost - s.Cost,
                           LastName = re.Last_name,
                           FirstName = re.First_name,
                           MiddleName = re.Middle_name
                       };

            return View(data.ToList());
        }

        //2.4
        public ActionResult Index2_4(string DistrictName, int? Number_of_rooms)
        {
            if (Number_of_rooms == null || Number_of_rooms <= 0 || string.IsNullOrEmpty(DistrictName))
            {
                ModelState.AddModelError("", "Некорректные параметры поиска.");
                return View();
            }

            var totalCost = (from r in db.Real_estate_objects
                             join d in db.Districts on r.District equals d.District_id
                             where d.District_name.Contains(DistrictName) && r.Number_of_rooms == Number_of_rooms
                             select r.Cost).Sum();

            ViewBag.TotalCost = totalCost;
            ViewBag.DistrictName = DistrictName;
            ViewBag.Number_of_rooms = Number_of_rooms;

            return View();
        }

        //2.5
        public ActionResult Index2_5(SearchModelForTask2_5 searchModel)
        {
            var sales = db.Sale
                .Where(s => s.Realtor.Last_name.Contains(searchModel.Last_name))
                .Select(s => s.Cost);

            ViewBag.MinCost = sales.Min();
            ViewBag.MaxCost = sales.Max();

            return View();
        }

        //2.6
        public ActionResult Index2_6(SearchModelForTask2_6 searchModel)
        {
            var averageEvaluation = (from r in db.Real_estate_objects
                                     join d in db.Districts on r.District equals d.District_id
                                     join e in db.Evaluations on r.Object_id equals e.Object_id
                                     where d.District_name.Contains(searchModel.DistrictName)
                                     select e.Evaluation).Average();

            ViewBag.AverageEvaluation = averageEvaluation;

            return View();
        }
    }
}