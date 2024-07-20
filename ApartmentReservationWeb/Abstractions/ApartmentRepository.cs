using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ApartmentReservationWeb.Abstractions
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly OccupancyContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ApartmentRepository(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public int AddApartment(ApartmentInfoDto apartmentInfoDto)
        {


            if (_context.Apartments.Any(x => x.Latitude == apartmentInfoDto.Latitude
                && x.Longitude == apartmentInfoDto.Longitude && x.OwnerId == apartmentInfoDto.OwnerId))
                throw new Exception("Apartment like this is already exist!");

            var entity = _mapper.Map<ApartmentInfo>(apartmentInfoDto);

            _context.Add(entity);
            _context.SaveChanges();
            _cache.Remove("apartments");

            return entity.Id;
        }

        public IEnumerable<ApartmentInfo> GetAllApartments()
        {
            if (_cache.TryGetValue("apartments", out List<ApartmentInfo> list)) 
                return list;

            list = _context.Apartments.Select(_mapper.Map<ApartmentInfo>).ToList();

            _cache.Set("apartments", list, TimeSpan.FromMinutes(30));

            return list;
        }

        public ApartmentInfo GetApartmentById(int id)
        {
            ApartmentInfo apartment;

            if (_cache.TryGetValue("apartments", out List<ApartmentInfo> list))
                return list.FirstOrDefault(x => x.Id == id);

            return _context.Apartments.FirstOrDefault(x => x.Id == id);
        }

        public ApartmentInfo RemoveApartment(int id)
        {
            var apartment = _context.Apartments.FirstOrDefault(x => x.Id == id);

            if (apartment == null)
                throw new Exception("No apartment like this!");

            _context.Apartments.Remove(apartment);
            _context.SaveChanges();
            _cache.Remove("apartments");

            return apartment;
        }
    }
}
