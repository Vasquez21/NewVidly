﻿using AutoMapper;
using NewVidly.Dtos;
using NewVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewVidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Rental, RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}