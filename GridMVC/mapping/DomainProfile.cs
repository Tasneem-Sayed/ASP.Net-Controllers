using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GridMVC.Entities;
using GridMVC.Models;

namespace GridMVC.mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Room, RoomVM>();
            CreateMap<RoomVM, Room>();
            CreateMap<RoomBoking, BookingVM>();
            CreateMap<BookingVM, RoomBoking>();
        }
    }
}
