using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
	public class CategoryListItem
    {
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public required string Description { get; set; }
    }
}
