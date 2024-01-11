using Microsoft.Build.Framework;

namespace Test.Models
{
	public class Location
	{
		public int LocationId { get; set; }
        [Required]
        public string Name {get; set; }
        [Required]
        public string Adress { get; set; }
        
        public int? HouseNumber { get; set; }
        [Required]
        public string Description { get; set; }

// lijst van seingevers
		public IList<Signalman> Signalmen { get; set; } = new List<Signalman>();
	}
}
