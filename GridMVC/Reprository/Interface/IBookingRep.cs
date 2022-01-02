using GridMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Reprository.Interface
{
    public interface IBookingRep
    {
        IQueryable<BookingVM> Get();
        BookingVM GetById(int id);
        void Add(BookingVM room);
        void Edit(BookingVM room);
        void Delete(int id);
    }
}
