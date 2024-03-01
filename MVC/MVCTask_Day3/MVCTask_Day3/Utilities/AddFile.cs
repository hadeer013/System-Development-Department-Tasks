namespace MVCTask_Day3.Utilities
{
	public class AddFile
	{
		public static string UploadImage(IFormFile image)
		{
			var folderPath = "wwwroot/images";
			var filename = $"{Guid.NewGuid()}{Path.GetFileName(image.FileName)}";

			var filepath=Path.Combine(folderPath, filename);
			using var fs=new FileStream(filepath, FileMode.Create);

			image.CopyTo(fs);
			return filename;
		}
	}
}
