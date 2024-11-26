using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
	public class Log : BaseEntity
	{
		public required string Message { get; set; }
		public required string LogLevel { get; set; } // Info, Error, Warning, etc.
	}

}
