namespace KyivMap.Controllers
{
	using System;
	using System.Text.RegularExpressions;
	using System.Web.Mvc;
	using Models;
	using TSFramework.Dao;

	public class HistoryBuildingController : DaoControllerBase<HistoryBuilding>
	{
		public HistoryBuildingController(IDao<HistoryBuilding> dao) : base(dao)
		{
		}

		public override ActionResult Index(int? page)
		{
			return View(Dao.SelectAll());
		}

		public string ParseData()
		{
			try
			{
				var data = Dao.SelectAll();
				foreach (var entity in data)
				{
					if (entity.Description != null)
					{
						Regex regex =
							new Regex(
								"(?:(?:ht|f)tps?://)?(?:[\\\\-\\\\w]+:[\\\\-\\\\w]+@)?(?:[0-9a-z][\\\\0-9a-z]*[0-9a-z]\\\\.)+[a-z]{2,6}(?::\\d{1,5})?(?:[?/\\\\\\\\#][?!^$.(){}:|=[\\\\]+\\\\-/\\\\\\\\*;&~#@,%\\wА-Яа-я]*)?");

						foreach (Match m in regex.Matches(entity.Description))
						{
							entity.Url = m.Value;
						}
						entity.Description = regex.Replace(entity.Description, string.Empty);
					}
				}
				Dao.SaveChanges();
			}
			catch (Exception e)
			{
				return e.ToString();
			}
			return "Success!";
		}
	}
}