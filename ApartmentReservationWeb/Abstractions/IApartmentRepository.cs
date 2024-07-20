using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;

namespace ApartmentReservationWeb.Abstractions
{
    public interface IApartmentRepository
    {
        int AddApartment(ApartmentInfoDto apartmentInfoDto);
        ApartmentInfo GetApartmentById(int id);
        IEnumerable<ApartmentInfo> GetAllApartments();
        ApartmentInfo RemoveApartment(int id);
    }
}
