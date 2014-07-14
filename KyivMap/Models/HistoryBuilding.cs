namespace KyivMap.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using TSFramework.Validation;

	public class HistoryBuilding
	{
		[Key]
		public int Id { get; set; }

		[RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Только латинские буквы и цифры!")]
		[Display(Name = "Ключ записи")]
		public string Key { get; set; }

		[Required]
		[Display(Name = "Имя объекта")]
		public string Name { get; set; }

		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Display(Name = "Фото")]
		public string Image { get; set; }

		[Display(Name = "Ссылка")]
		public string Url { get; set; }

		[Display(Name = "Год начала постройки")]
		public int StartBuildingYear { get; set; }

		[Display(Name = "Год конца постройки")]
		public int EndBuildingYear { get; set; }

		[Display(Name = "Год начала использования")]
		public int StartUseYear { get; set; }

		[Display(Name = "Год конца использования")]
		public int EndUseYear { get; set; }

		[Display(Name = "Год сноса")]
		public int DemolitionYear { get; set; }

		[Display(Name = "Тип постройки")]
		public BuildingType Type { get; set; }
	}
}