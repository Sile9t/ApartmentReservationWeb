using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.UserModel;
using AutoMapper;

namespace ApartmentReservationWeb.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ApartmentInfoDto, ApartmentInfo>().ReverseMap();
            CreateMap<ReservationDateDto, ReservationDate>().ReverseMap();
        }
    }
}
