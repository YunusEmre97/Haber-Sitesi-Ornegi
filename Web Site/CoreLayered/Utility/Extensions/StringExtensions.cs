using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utility.Extensions
{
	public static class StringExtensions
	{
		public static string ToSlug(this string text)
		{
			// shift 3 e bas = (^)
			string slug = text.ToLowerInvariant();
			slug = slug.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");
			slug = Regex.Replace(slug,@"[^a-z0-9\s-]", "");
			slug = Regex.Replace(slug,@"\s+", " ").Trim();
			slug = slug.Replace(" ", "-");
			return slug;
		}
	}
}
