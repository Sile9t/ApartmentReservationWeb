using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;

namespace ApartmentReservationWeb.Services
{
    public class DateService
    {
        private readonly IDateRepository _repository;
        public DateService(IDateRepository repository)
        {
            _repository = repository;
        }

        public int AddDate(ReservationDateDto reservationDateDto)
        {
            return _repository.AddDate(reservationDateDto);
        }

        public IEnumerable<ReservationDate> GetAllDates()
        {
            return _repository.GetAllDates();
        }

        public int UpdateDate(ReservationDate reservationDate)
        {
            return _repository.UpdateDate(reservationDate);
        }

        public ReservationDateDto RemoveDate(int id)
        {
            return _repository.RemoveDate(id);
        }

        //Do to: data validation, exception catching
    }
}
