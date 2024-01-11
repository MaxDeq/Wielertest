using Microsoft.Build.Framework;

namespace Test.Models
{
	public class Signalman
	{
		public int SignalmanId { get; set; }

		public int? LocationId { get; set; }

		[Required]
		public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }

		public Location? Location { get; set; }


	}
}
