using AutoMapper;
using Next.Steps.Application.Dtos;
using Next.Steps.Domain.Entities;
using System;

namespace Next.Steps.Application.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonReadDto>()
                .ForMember(p => p.Birthdate, opt =>
                opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd")));

            CreateMap<PersonWriteDto, Person>()
                .ForMember(p => p.BirthDate, opt =>
                opt.MapFrom(src => (DateTime)src.BirthDate));

            CreateMap<PersonUpdateDto, Person>()
                .ForMember(p => p.BirthDate, opt =>
                opt.MapFrom(src => (DateTime)src.BirthDate));

            CreateMap<Hobby, HobbyReadDto>();

            CreateMap<HobbyWriteDto, Hobby>()
                .ForMember(p => p.PersonId, opt => opt.Ignore());

            CreateMap<HobbyUpdateDto, Hobby>();
        }
    }
}