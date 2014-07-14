namespace KyivMap.Data.Daos
{
	using Models;
	using TSFramework.Dao;

	public class HistoryBuildingDao : DaoBase<HistoryBuilding>
	{
		public HistoryBuildingDao(KyivMapDbContext container)
			: base(container)
		{
		}
	}
}