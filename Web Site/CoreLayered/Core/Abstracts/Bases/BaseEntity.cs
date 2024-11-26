using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Bases
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public bool Deleted { get; set; } = false;
	}
}
