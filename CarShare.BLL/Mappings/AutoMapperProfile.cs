﻿using AutoMapper;
using CarShare.BLL.DTOs;
using CarShare.BLL.DTOs.Car;
using CarShare.BLL.DTOs.Rental;
using CarShare.BLL.DTOs.User;
using CarShare.DAL.Enums;
using CarShare.DAL.Models;

namespace CarShare.BLL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mappings
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            // Map User entity to UserResponseDTO (excluding sensitive data like PasswordHash)
            CreateMap<User, UserResponseDTO>();

            // Car Mappings
            CreateMap<CarCreateDTO, Car>()
                .ForMember(dest => dest.CarImages, opt => opt.Ignore())
                .ForMember(dest => dest.RentalStatus, opt => opt.MapFrom(_ => RentalStatus.Available))
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(_ => false));

            CreateMap<Car, CarResponseDTO>()
                .ForMember(dest => dest.ImageUrls,
                    opt => opt.MapFrom(src => src.CarImages.Select(img => img.ImageUrl)))
                .ForMember(dest => dest.OwnerName,
                    opt => opt.MapFrom(src => $"{src.Owner.FirstName} {src.Owner.LastName}"));

            // Rental Mappings
            CreateMap<RentalProposalDTO, RentalProposal>();
            CreateMap<RentalProposal, RentalResponseDTO>()
                .ForMember(dest => dest.CarTitle,
                    opt => opt.MapFrom(src => src.Car.Title))
                .ForMember(dest => dest.RenterName,
                    opt => opt.MapFrom(src => $"{src.Renter.FirstName} {src.Renter.LastName}"));
        }
    }
}