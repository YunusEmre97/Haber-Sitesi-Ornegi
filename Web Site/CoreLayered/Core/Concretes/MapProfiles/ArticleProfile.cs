using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.MapProfiles
{
	public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<Article, ArticleListItem>().ForMember(
				dest => dest.ShortContent,
				opt => opt.MapFrom(src => src.Content.Length >= 150? src.Content.Substring(0, 150): src.Content)).ForMember(
				dest => dest.Categories,
				opt => opt.MapFrom(src => src.ArticleCategories.Select(x => x.Category)))
				.ForMember(
				dest => dest.Tags,
				opt => opt.MapFrom(src => src.Tags));

		}
	}
}
