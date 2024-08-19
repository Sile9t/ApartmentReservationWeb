using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using AutoMapper;

namespace ApartmentReservationWeb.Services
{
    public class OccupancyService
    {
        private readonly OccupancyContext _context;
        private readonly IMapper _mapper;

        public OccupancyService(OccupancyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddOccupancy(OccupancyDto occupancyDto)
        {
            if (_context.Occupancies.Any(x =>
                    x.OccupancyDate == occupancyDto.OccupancyDate
                    && x.EvictionDate == occupancyDto.EvictionDate
                    && x.OccupancyStateId == 1))
                throw new Exception("Occupancy date is reserved!");

            var entity = _mapper.Map<Occupancy>(occupancyDto);
            _context.Occupancies.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public Occupancy GetOccupancy(int id)
        {
            var occupancy = _context.Occupancies.FirstOrDefault(x => x.Id == id);

            if (occupancy == null)
                throw new Exception("No occupancy like this!");

            return occupancy;
        }

        public IEnumerable<Occupancy> GetOccupancies(string ownerId)
        {
            var list = _context.Occupancies.Select(_mapper.Map<Occupancy>)
                .Where(x => x.Apartment.OwnerId == ownerId).ToList();

            return list;
        }

        public Occupancy RemoveOccupancy(int id)
        {
            var occupancy = _context.Occupancies.FirstOrDefault(x => x.Id == id);

            if (occupancy == null)
                throw new Exception("No occupancy like this!");

            _context.Occupancies.Remove(occupancy);
            _context.SaveChanges();

            return occupancy;
        }

        public bool UpdateOccupancy(OccupancyDto occupancyDto, int id)
        {
            if (!_context.Occupancies.Any(x => x.Id == id))
                return false;

            var entity = _mapper.Map<Occupancy>(occupancyDto);
            entity.ApartmentId = id;

            _context.Occupancies.Update(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
