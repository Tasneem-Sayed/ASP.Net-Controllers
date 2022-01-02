using GridMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridMVC.Reprository
{
   public interface IRoomRep
    {
        IQueryable<RoomVM> Get();
        RoomVM GetById(int id);
        void Add(RoomVM room);
        void Edit(RoomVM room);
        void Delete(int id);
    }
}
