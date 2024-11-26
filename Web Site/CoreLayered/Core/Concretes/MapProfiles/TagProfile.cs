using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Utility.Extensions;

namespace Core.Concretes.MapProfiles
{
	public class TagProfile : Profile
	{
		public TagProfile()
		{
			CreateMap<Tag, TagListItem>()
				.ForMember(
				dest => dest.Slug,
				opt => opt.MapFrom(src=>src.Name.ToSlug()));
		}
	}
}
