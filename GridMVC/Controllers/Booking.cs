using GridMVC.Models;
using GridMVC.Reprository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Controllers
{
    public class Booking : Controller
    {
        private readonly IBookingRep rep;

        public Booking(IBookingRep rep)
        {
            this.rep = rep;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PersonList()
        {
            try
            {

                var persons = rep.Get();
                return Json(new { Result = "OK", Records = persons });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Bug", ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreatePerson(BookingVM person)
        {
            try
            {
                rep.Add(person);
                return Json(new { Result = "OK", Record = person });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdatePerson(BookingVM person)
        {
            try
            {
                rep.Edit(person);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = rep.GetById(id);

            return View(data);
        }
        [HttpPost]
        public JsonResult DeletePerson(int personId)
        {
            try
            {
                rep.Delete(personId);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }

        }
    }
}
