using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;

namespace ApartmentReservationWeb.Abstractions
{
    public interface IDateRepository
    {
        int AddDate(ReservationDateDto reservationDateDto);
        IEnumerable<ReservationDate> GetAllDates();
        int UpdateDate(ReservationDate reservationDate);
        ReservationDateDto RemoveDate(int id);
    }
}
