using AutoMapper;
using GridMVC.Entities;
using GridMVC.HotelDB;
using GridMVC.Models;
using GridMVC.Reprository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Reprository
{
    public class BookingRep:IBookingRep
    {
        private readonly HoteldbContext dB;

        public IMapper Mapper { get; }

        public BookingRep(HoteldbContext dB, IMapper mapper)
        {
            this.dB = dB;
            Mapper = mapper;
        }
        public IQueryable<BookingVM> Get()
        {
            IQueryable<BookingVM> data = GetAllRooms();
            return data;
        }


        public void Add(BookingVM Dpt)
        {
            
            var data = Mapper.Map<RoomBoking>(Dpt);
           
            dB.RoomBoking.Add(data);
            dB.SaveChanges();

        }

        public BookingVM GetById(int id)
        {
            BookingVM data = GetRoomById(id);
            return data;
        }



        public void Edit(BookingVM Dpt)
        {
            
            var data = Mapper.Map<RoomBoking>(Dpt);
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
        private BookingVM GetRoomById(int id)
        {
            return dB.RoomBoking.Where(a => a.BookingId == id)
                .Select(a => new BookingVM
                {
                    BookingId = a.BookingId,
                    GuestName = a.GuestName,
                    BookingFrom = a.BookingFrom,
                    BookingTo = a.BookingTo,
                    AssignRoomId = a.Room.RoomId,
                    RoomNum = a.Room.RoomNo,
                    AdultsNum = a.AdultsNum,
                    GuestAddress = a.GuestAddress,
                    TotalAmount = a.TotalAmount

                })
                .FirstOrDefault();
        }
        private IQueryable<BookingVM> GetAllRooms()
        {
            return dB.RoomBoking.Select(a => new BookingVM
            {
                BookingId = a.BookingId,
                GuestName = a.GuestName,
                BookingFrom = a.BookingFrom,
                BookingTo = a.BookingTo,
                AssignRoomId = a.AssignRoomId,
                RoomNum = a.RoomNum,
                AdultsNum = a.AdultsNum,
                GuestAddress = a.GuestAddress,
                TotalAmount = a.TotalAmount
               
            });
        }

       
    }
}

