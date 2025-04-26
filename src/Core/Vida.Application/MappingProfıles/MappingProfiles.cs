using AutoMapper;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Dtos.EventDtos;
using Vida.Application.Dtos.NewsDtos;
using Vida.Application.Dtos.SpaceDtos;
using Vida.Domain.Entities.EventEntities;
using Vida.Domain.Entities.News;
using Vida.Domain.SpaceEntities;

namespace Vida.Application.MappingProfıles;
public class MappingProfiles: Profile
{
	public MappingProfiles()
	{
		CreateMap<Space, SpaceResponse>();

		CreateMap<CourseReservationRequest, CourseReservation>();

		CreateMap<SpaceReservationRequest, SpaceReservation>();

        CreateMap<News, NewsResponse>();

		CreateMap<Event, EventResponse>();

		CreateMap<EventRegistration, EventRegistrationResponse>();

		CreateMap<EventRegistrationRequest, EventRegistration>();

    }
}