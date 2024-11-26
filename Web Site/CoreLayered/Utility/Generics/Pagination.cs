using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Generics
{
	public class Pagination<T>
	{
		public IEnumerable<T> Items { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
		public int Total { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPages { get; set; }
		public int Limit { get; set; }
		public Pagination(IEnumerable<T> data, int page, int limit)
		{
			CurrentPages = page;
			Limit = limit;
			Total = data.Count();
			TotalPages = (int)Math.Ceiling((double)Total / limit);
			Start = CurrentPages - 3 > 1 ? CurrentPages - 3 : 1;
			End = CurrentPages + 3 < TotalPages ? CurrentPages + 3 : TotalPages;
			Items = data.Skip((page - 1) * limit).Take(limit);
		}
		public static Pagination<T> Create(IEnumerable<T> data, int page, int limit)
		{
			return new Pagination<T>(data, page, limit);
		}
	}
}
