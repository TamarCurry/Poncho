using Poncho.Display;
using Poncho.Geom;


namespace Poncho.Interfaces
{
	/// <summary>
	/// Interface for a class that loads textures and returns Image instances.
	/// </summary>
	public interface IAppImages
	{
		/// <summary>
		/// Retrieves an image for the specified texture.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <param name="pivot"></param>
		/// <param name="rect"></param>
		/// <returns></returns>
		Image GetImage(string path);
		Image GetImage(string path, Pivot pivot);
		Image GetImage(string path, PivotF pivot);
		Image GetImage(string path, string name);
		Image GetImage(string path, ImageRect rect);
		Image GetImage(string path, ImageRectF rect);
		Image GetImage(string path, string name, Pivot pivot);
		Image GetImage(string path, string name, PivotF pivot);
		Image GetImage(string path, ImageRect rect, Pivot pivot);
		Image GetImage(string path, ImageRectF rect, Pivot pivot);
		Image GetImage(string path, ImageRect rect, PivotF pivot);
		Image GetImage(string path, ImageRectF rect, PivotF pivot);
		Image GetImage(string path, string name, ImageRect rect);
		Image GetImage(string path, string name, ImageRect rect, Pivot pivot);
	}
}
