namespace KyivMap.Data
{
	using System.Data.Entity;
	using Models;

	public class KyivMapDbContext : DbContext
	{
		public KyivMapDbContext() : base("kyivmap")
		{
		} 

		public DbSet<HistoryBuilding> Buildings { get; set; }
	}
}