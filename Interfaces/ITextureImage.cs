using Poncho.Geom;

namespace Poncho.Interfaces
{
	public interface ITextureImage
	{
		string name { get; }
		Pivot pivot { get; }
		ImageRect rect { get; }
	}
}
