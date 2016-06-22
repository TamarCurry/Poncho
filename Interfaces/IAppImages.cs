using Poncho.Display;
using Poncho.Geom;

namespace Poncho.Interfaces
{
	public interface IAppImages
	{
		Image GetImage(string path);
		Image GetImage(string path, Pivot pivot);
		Image GetImage(string path, string name);
		Image GetImage(string path, ImageRect rect);
		Image GetImage(string path, string name, Pivot pivot);
		Image GetImage(string path, ImageRect rect, Pivot pivot);
		Image GetImage(string path, string name, ImageRect rect);
		Image GetImage(string path, string name, ImageRect rect, Pivot pivot);
	}
}
