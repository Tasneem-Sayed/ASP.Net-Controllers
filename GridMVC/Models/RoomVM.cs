using GridMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Models
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public byte[] RoomImg { get; set; }
        public decimal RoomPrice { get; set; }
        public int BookingStatusId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomDesc { get; set; }
        public int RoomCapicty { get; set; }
        public bool IsActive { get; set; }
        public string? BookingId { get; set; }

        public virtual RoomBoking Booking { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
