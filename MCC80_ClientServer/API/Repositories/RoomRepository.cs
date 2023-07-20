using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _context;

        public RoomRepository(BookingDbContext context)
        {
            _context = context;
        }

        //GETALL ROOM
        public IEnumerable<Room> GetAll()
        {
            return _context.Set<Room>()
                           .ToList();
        }

        //GETBYID ROOM
        public Room? GetByGuid(Guid guid)
        {
            var data = _context.Set<Room>()
                               .Find(guid);
            _context.ChangeTracker.Clear();
            return data;
        }

        //CREATE ROOM
        public Room? Create(Room room)
        {
            try
            {
                _context.Set<Room>()
                        .Add(room);
                _context.SaveChanges();
                return room;
            }
            catch
            {
                return null;
            }
        }

        //UPDATE ROOM
        public bool Update(Room room)
        {
            try
            {
                _context.Entry(room)
                        .State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DELETE ROOM
        public bool Delete(Room room)
        {
            try
            {
                _context.Set<Room>()
                        .Remove(room);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
