﻿using lab_7.Models;
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

        //2.7
        public ActionResult Index2_7(SearchModelForTask2_7 searchModel)
        {
            var floor2Counts = (from r in db.Real_estate_objects
                                join d in db.Districts on r.District equals d.District_id
                                where r.Floor == searchModel.Floor
                                select new { District = d.District_name, r.Floor })
                                .AsEnumerable() // Преобразуем результаты запроса в памяти, потому что District_name это text и нельзя группировать типы text, можно только varchar
                                .GroupBy(r => r.District)
                                .Select(g => new ModelForTask2_7
                                {
                                    District = g.Key,
                                    Count = g.Count()
                                })
                                .ToList();

            return View(floor2Counts);
        }

        //2.8
        public ActionResult Index2_8(string criteriaName, string realtorName)
        {   //ищем по риелтору и критерию оценки, тип не был предусмотрен в задании
            var averageEvaluation = (from r in db.Real_estate_objects
                                     join e in db.Evaluations on r.Object_id equals e.Object_id
                                     join c in db.Evaluation_criteria on e.Criteria_id equals c.Criteria_id
                                     join s in db.Sale on r.Object_id equals s.Object_id
                                     join re in db.Realtor on s.Realtor_id equals re.Realtor_id
                                     where c.Criteria_name.Contains(criteriaName) && re.Last_name.Contains(realtorName)
                                     select e.Evaluation).Average();

            ViewBag.averageEvaluation = averageEvaluation; //6
            ViewBag.criteriaName = criteriaName; //безопасность
            ViewBag.realtorName = realtorName; //короткова

            return View();
        }

        //2.9
        public ActionResult Index2_9(DateTime? startDate = null, DateTime? endDate = null)
        {
            var averagePricePerSquareMeter = (from s in db.Sale
                                              join r in db.Real_estate_objects on s.Object_id equals r.Object_id
                                              where s.Sale_date >= startDate && s.Sale_date <= endDate
                                              select r.Cost / r.Area).Average();

            ViewBag.averagePricePerSquareMeter = averagePricePerSquareMeter; //166666,66666666666666666666
            ViewBag.startDate = startDate; //4.01.22
            ViewBag.endDate = endDate; //22.01.22

            return View();
        }
    }
}