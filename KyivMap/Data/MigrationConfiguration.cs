using System.Data.Entity.Migrations;

namespace KyivMap.Data
{
	public sealed class MigrationConfiguration : DbMigrationsConfiguration<KyivMapDbContext>
	{
		public MigrationConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(KyivMapDbContext context)
		{

		}
	}
}