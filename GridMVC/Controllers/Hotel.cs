
using AutoMapper;
using GridMVC.Entities;
using GridMVC.HotelDB;
using GridMVC.Models;
using GridMVC.Reprository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Controllers
{
    public class Hotel : Controller
    {
  
        private readonly IRoomRep rep;

     

        public Hotel(IRoomRep rep )
        {
           
            this.rep = rep;
        }

        public IActionResult Index()
        {
            return View() ;
        }
        //Retrive Data
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
        public JsonResult CreatePerson(RoomVM person)
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
        public JsonResult UpdatePerson(RoomVM person)
        {
            try
            {
                rep.Edit(person);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR",  ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeletePerson(int id)
        {
            try
            {
               rep.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR",  ex.Message });
            }
        }
    }
}
