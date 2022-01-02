using GridMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Models
{
    public class BookingVM
    {
       

        public int BookingId { get; set; }
        public string GuestName { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public int AssignRoomId { get; set; }
        public string RoomNum { get; set; }
        public int? AdultsNum { get; set; }
        public string GuestAddress { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
