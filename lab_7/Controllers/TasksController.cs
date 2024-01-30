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
        {   
            //ищем по риэлтору и критерию оценки, тип не был предусмотрен в задании
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
            //ищем по дате от и до, тип не был предусмотрен в задании
            var averagePricePerSquareMeter = (from s in db.Sale
                                              join r in db.Real_estate_objects on s.Object_id equals r.Object_id
                                              where s.Sale_date >= startDate && s.Sale_date <= endDate
                                              select r.Cost / r.Area).Average();

            ViewBag.averagePricePerSquareMeter = averagePricePerSquareMeter; //166666,66666666666666666666
            ViewBag.startDate = startDate; //4.01.22
            ViewBag.endDate = endDate; //22.01.22

            return View();
        }

        //2.10
        public ActionResult Index2_10()
        {
            var realtorBonuses = (from s in db.Sale
                                  join r in db.Realtor on s.Realtor_id equals r.Realtor_id
                                  select new { Sale = s, Realtor = r })
                     .AsEnumerable()
                     .GroupBy(sr => new { sr.Realtor.Last_name, sr.Realtor.First_name, sr.Realtor.Middle_name })
                     .Select(g => new ModelForTask2_10
                     {
                         LastName = g.Key.Last_name,
                         FirstName = g.Key.First_name,
                         MiddleName = g.Key.Middle_name,
                         Bonus = g.Count() > 0 ? (g.Sum(x => x.Sale.Cost) * 0.05m * 0.87m).ToString() : "Риэлтор еще ничего не продал"
                     });

            return View(realtorBonuses.ToList());

        }

        //2.11
        public ActionResult Index2_11()
        {
            var data = (from s in db.Sale
                        join r in db.Realtor on s.Realtor_id equals r.Realtor_id
                        select new { Sale = s, Realtor = r })
                     .AsEnumerable()
                     .GroupBy(sr => new { sr.Realtor.Last_name, sr.Realtor.First_name, sr.Realtor.Middle_name })
                     .Select(g => new ModelForTask2_11
                     {
                         LastName = g.Key.Last_name,
                         FirstName = g.Key.First_name,
                         MiddleName = g.Key.Middle_name,
                         Count = g.Count()
                     });

            return View(data.ToList());
        }

        //2.12
        public ActionResult Index2_12(SearchModelForTask2_12 searchModel)
        {
            var dataFromDB = (from o in db.Real_estate_objects
                              join m in db.Building_materials on o.Building_material equals m.Material_id
                              where o.Floor == searchModel.Floor
                              select new { Material = m.Material_name, Cost = o.Cost })
                             .AsEnumerable()
                             .GroupBy(x => x.Material)
                             .Select(grp => new
                             {
                                 Material = grp.Key,
                                 AverageCost = grp.Average(x => x.Cost)
                             });

            var data = dataFromDB.Select(x => new ModelForTask2_12
            {
                BuildingMaterial = x.Material,
                AverageCost = x.AverageCost
            }).ToList();

            return View(data);
        }

        //2.13
        public ActionResult Index2_13()
        {
            var rawData = (from re in db.Real_estate_objects
                           join d in db.Districts on re.District equals d.District_id
                           select new { DistrictName = d.District_name, Address = re.Address, Cost = re.Cost, Floor = re.Floor })
                           .AsEnumerable();

            // Производим сортировку и группировку в коде C#
            var processedData = rawData
                .GroupBy(x => x.DistrictName)
                .Select(g => new
                {
                    DistrictName = g.Key,
                    TopThreeProperties = g.OrderByDescending(p => p.Cost).ThenBy(p => p.Floor).Take(3)
                })
                .SelectMany(x => x.TopThreeProperties.Select(y => new ModelForTask2_13
                {
                    DistrictName = x.DistrictName,
                    Address = y.Address,
                    Cost = y.Cost,
                    Floor = y.Floor
                }))
                .ToList();

            return View(processedData);
        }

    }
}