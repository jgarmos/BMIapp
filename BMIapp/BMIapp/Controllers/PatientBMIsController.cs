using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using BMIapp.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;

namespace BMIapp.Controllers
{
    public class PatientBMIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientsCategoryCounter
        public ActionResult PatientsCategoryCounter()
        {
            var query = from p in db.PatientsBMI
                        group p by p.Category into g
                        select new
                        {
                            BMICategory = g.Key,
                            PatientCount = g.Count()
                        };

            var categoriesCount = query.ToList();


            List<PatientsCategoryCounter> listPatientCategoryCounter = new List<PatientsCategoryCounter>();
            foreach (var category in categoriesCount )
            {
                PatientsCategoryCounter patientsCategory = new PatientsCategoryCounter();
                patientsCategory.Category = category.BMICategory;
                patientsCategory.Count = category.PatientCount;
                listPatientCategoryCounter.Add(patientsCategory);
            }

            return View(listPatientCategoryCounter);
        }

        private class PatientBMIJson
        {
            public string User_Id { get; set; }
            public double Weight { get; set; }
            public double Height { get; set; }
        }

        // GET: PopulatePatientsBMI
        public ActionResult PopulatePatientsBMI()
        {

            using (StreamReader r = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/PatientsBMI.json")))
            {
                string json = r.ReadToEnd();
                List<PatientBMIJson> patientsBMIJson = JsonConvert.DeserializeObject<List<PatientBMIJson>>(json);
                foreach (var patientBmiJson in patientsBMIJson)
                {

                    //TODO: check if user exists
                    var user = db.Users.Single(u => u.Id == patientBmiJson.User_Id);

                    PatientBMI patientBMI = new PatientBMI(patientBmiJson.Weight, patientBmiJson.Height);
                    patientBMI.User = user;

                    db.PatientsBMI.Add(patientBMI);
                    
                }
                db.SaveChanges();
            }

            return View();
        }

        [Authorize]
        // GET: GetPatientInformation
        public ActionResult GetPatientInformation()
        {
            var userId = User.Identity.GetUserId();

            var query = from p in db.PatientsBMI
                        where p.User.Id == userId
                        select p;

            var patientInfo = query.ToList().FirstOrDefault();

            return View(patientInfo);
        }

    }
}
