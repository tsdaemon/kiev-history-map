
using ImageResizer;
namespace KyivMap.Controllers
{
	using System.Web.Mvc;
	using TSFramework.Utils;

	public class ImageController : TSFramework.Controllers.ImageController
	{
		public ImageController()
		{
			Settings = new ResizeSettings(300, 300, FitMode.Max, null);
		}

		public JsonResult GetFromWiki(string url)
		{
			var document = WebPageUtil.GetWebPage(url);
			var navigator = document.CreateNavigator();

			string imageSrc = navigator.With(n => n.SelectSingleNode("//table[@class='infobox']//img/@src")).With(n => n.Value);
			if (string.IsNullOrEmpty(imageSrc))
			{
				imageSrc = navigator.With(n => n.SelectSingleNode("//table[@class='infobox vcard']//img/@src")).With(n => n.Value);
			}
			if (string.IsNullOrEmpty(imageSrc))
			{
				imageSrc = navigator.With(n => n.SelectSingleNode("//img[@class='thumbimage']/@src")).With(n => n.Value);
			}
			string imageUrl = "http:" + imageSrc;
			return UploadRemote(imageUrl);
		}
	}
}