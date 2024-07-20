namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ApartFacilities
    {
        public int Id { get; set; }
        public virtual List<ApartFacility> FacilitiesList{ get; set; }
    }
}
