using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Services
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentService : ControllerBase
    {
        private readonly IApartmentRepository _repository;
        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("AddApartment")]
        public ActionResult<int> AddApartment(ApartmentInfoDto apartmentInfoDto)
        {
            try
            {
                return Ok(_repository.AddApartment(apartmentInfoDto));
            }
            catch (Exception ex) { return StatusCode(409); }
        }

        [HttpGet("GetApartmentById")]
        public ActionResult<ApartmentInfo?> GetApartmentById(int id)
        {
            try
            {
                return Ok(_repository.GetApartmentById(id));
            }
            catch (Exception ex) { return StatusCode(409); }
        }

        [HttpDelete("RemoveApartment")]
        public ActionResult<ApartmentInfo> RemoveApartment(int id)
        {
            try
            {
                return Ok(_repository.RemoveApartment(id));
            }
            catch (Exception ex) { return StatusCode(409); }
        }

        [HttpGet("GetAllApartments")]
        public ActionResult<IEnumerable<ApartmentInfo>> GetAllApartments()
        {
            try
            {
                return Ok(_repository.GetAllApartments());
            }
            catch (Exception ex) { return StatusCode(409); }
        }
    }
}
