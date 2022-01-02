using AutoMapper;
using GridMVC.Entities;
using GridMVC.HotelDB;
using GridMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Reprository
{
    public class RoomRep : IRoomRep
    {
        private readonly HoteldbContext dB;

        public IMapper Mapper { get; }

        public RoomRep(HoteldbContext dB,IMapper mapper)
        {
            this.dB = dB;
            Mapper = mapper;
        }
        public IQueryable<RoomVM> Get()
        {
            IQueryable<RoomVM> data = GetAllEmployees();
            return data;
        }


        public void Add(RoomVM Dpt)
        {
            //Department d = new Department();
            //d.DepartmentName = Dpt.DepartmentName;
            //d.DepartmentCode = Dpt.DepartmentCode;
            var data = Mapper.Map<Room>(Dpt);
            //Db.Employee.Add(data);
            dB.Rooms.Add(data);
            dB.SaveChanges();

        }

        public RoomVM GetById(int id)
        {
            RoomVM data = GetEmployeeById(id);
            return data;
        }



        public void Edit(RoomVM Dpt)
        {
            //var olddata = Db.Departments.Find(Dpt.Id);
            //olddata.DepartmentName = Dpt.DepartmentName;
            //olddata.DepartmentCode = Dpt.DepartmentCode;
            var data = Mapper.Map<Room>(Dpt);
            dB.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedObject = dB.Rooms.Find(id);
            dB.Rooms.Remove(DeletedObject);
            dB.SaveChanges();
        }

        //Refactor
        private RoomVM GetEmployeeById(int id)
        {
            return dB.Rooms.Where(a => a.RoomId == id)
                .Select(a => new RoomVM
                {
                    RoomId = a.RoomId,
                    RoomNo = a.RoomNo,
                    RoomImg = a.RoomImg,
                    RoomPrice = a.RoomPrice,
                    BookingStatusId = a.BookingStatusId,
                    RoomTypeId = a.RoomTypeId,
                    RoomDesc = a.RoomDesc,
                    RoomCapicty = a.RoomCapicty,
                    IsActive = a.IsActive,
                    BookingId = a.Booking.GuestName,
                })
                .FirstOrDefault();
        }
        private IQueryable<RoomVM> GetAllEmployees()
        {
            return dB.Rooms.Select(a => new RoomVM
            {
                RoomId = a.RoomId,
                RoomNo = a.RoomNo,
                RoomImg = a.RoomImg,
                RoomPrice = a.RoomPrice,
                BookingStatusId = a.BookingStatusId,
                RoomTypeId = a.RoomTypeId,
                RoomDesc = a.RoomDesc,
                RoomCapicty = a.RoomCapicty,
                IsActive = a.IsActive,
                BookingId = a.Booking.GuestName,
            });
        }
    }
}
