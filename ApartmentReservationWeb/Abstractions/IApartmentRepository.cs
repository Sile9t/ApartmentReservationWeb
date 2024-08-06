using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;

namespace ApartmentReservationWeb.Abstractions
{
    public interface IApartmentRepository
    {
        int AddApartment(ApartmentInfoDto apartmentInfoDto);
        ApartmentInfo GetApartmentById(int id);
        IEnumerable<ApartmentInfo> GetAllApartments();
        IEnumerable<ApartmentInfo> GetApartmentsByOwner(int id);
        ApartmentInfo RemoveApartment(int id);
    }
}
