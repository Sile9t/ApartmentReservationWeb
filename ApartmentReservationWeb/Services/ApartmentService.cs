using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Services
{
    public class ApartmentService
    {
        private readonly IApartmentRepository _repository;
        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }

        public int AddApartment(ApartmentInfoDto apartmentInfoDto)
        {
            return _repository.AddApartment(apartmentInfoDto);
        }

        public ApartmentInfo? GetApartmentById(int id)
        {
            return _repository.GetApartmentById(id);
        }

        public ApartmentInfo RemoveApartment(int id)
        {
            return _repository.RemoveApartment(id);
        }

        public IEnumerable<ApartmentInfo> GetApartmentsByOwnerId(int? id)
        {
            if (id == null) return Enumerable.Empty<ApartmentInfo>();

            return _repository.GetApartmentsByOwnerId(id);
        }

        public IEnumerable<ApartmentInfo> GetAllApartments()
        {
            return _repository.GetAllApartments();
        }

        //To do: data validation
    }
}
