using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.data
{
	public class WielerwedstrijdDbContext : DbContext
	{
		public WielerwedstrijdDbContext(DbContextOptions<WielerwedstrijdDbContext> options) : base(options)
		{

		}

		public DbSet<Location> Locations => Set<Location>();
		public DbSet<Signalman> Signalmen => Set<Signalman>();

		public void Seed()
		{
			Locations.AddRange(
				new Location()
				{
					Name = "Zulte",
					Adress = "adres in zulte",
					HouseNumber = 13,
					Description = "in de wijk",
					Signalmen = new List<Signalman>
					{
						new Signalman()
						{
							Name = "Hallo",
							FirstName = "Bob"
						},
						new Signalman()
						{
							Name = "Janssens",
							FirstName = "Henk"
						},
						new Signalman()
						{
							Name = "Pet",
							FirstName = "Jan met de"
						}

					}
				},
				new Location()
				{
					Name = "Waregem",
					Adress = "adres in Waregem",
					HouseNumber = 69,
					Description = "op de Aarde"

				},
				new Location()
				{
					Name = "Poperinge",
					Adress = "adres in Poperinge",
					HouseNumber = 1,
					Description = "bij de overweg"
				},
				new Location()
				{
					Name = "Proven",
					Adress = "adres in Proven",
					HouseNumber = 82,
					Description = "baan naar Watou"
				},
				new Location()
				{
					Name = "Kortrijk",
					Adress = "adres in Kortrijk",
					HouseNumber = 100,
					Description = "bij VIVES",
					Signalmen = new List<Signalman>
					{
						new Signalman()
						{
							Name = "Ree",
							FirstName = "Tomatenpu"
						}
					}

				}
				);
			SaveChanges();
		}




    }

}
