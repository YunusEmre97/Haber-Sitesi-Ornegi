using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Utility.Extensions;

namespace Core.Concretes.MapProfiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryListItem>()
				.ForMember(
				dest => dest.Slug,
				opt => opt.MapFrom(src => src.Name.ToSlug()));
		}
	}
}
