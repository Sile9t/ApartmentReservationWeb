using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace ApartmentReservationWeb.Abstractions
{
    public class DateRepository : IDateRepository
    {
        private readonly OccupancyContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public DateRepository(OccupancyContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddDate(ReservationDateDto reservationDateDto)
        {
            if (_context.ReservationDates.Any(x => x.Date == reservationDateDto.Date
                    && x.ApartmentId == reservationDateDto.ApartmentId
                    && x.OccupancyId == reservationDateDto.OccupancyId))
                throw new Exception("This date is already exists!");

            var entity = _mapper.Map<ReservationDate>(reservationDateDto);

            _context.ReservationDates.Add(entity);
            _cache.Remove("dates");

            return entity.Id;
        }

        public IEnumerable<ReservationDate> GetAllDates()
        {
            if (_cache.TryGetValue("dates", out List<ReservationDate> dates))
                return dates;

            dates = _context.ReservationDates.ToList();

            _cache.Set("dates", dates, TimeSpan.FromMinutes(30));

            return dates;
        }

        public ReservationDateDto RemoveDate(int id)
        {
            var date = _context.ReservationDates.FirstOrDefault(x => x.Id == id);

            if (date == null)
                throw new Exception("No date like this!");

            _context.ReservationDates.Remove(date);

            return _mapper.Map<ReservationDateDto>(date);
        }

        public int UpdateDate(ReservationDate reservationDate)
        {
            if (!_context.ReservationDates.Any(x => x.Id == reservationDate.Id))
                throw new Exception("No date like this!");

            _context.Update(reservationDate);
            _cache.Remove("dates");

            return reservationDate.Id;
        }
    }
}
