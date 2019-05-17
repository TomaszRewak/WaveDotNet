using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Rain.Designer.Views.Plots.Converters
{
	internal class BitmapToImageSourceConverter : ValueConverter<Bitmap, ImageSource>
	{
		public override ImageSource Convert(Bitmap value)
		{
			if (value == null)
				return null;

			var stream = new MemoryStream();
			value.Save(stream, ImageFormat.Bmp);
			stream.Seek(0, SeekOrigin.Begin);

			var image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = stream;
			image.EndInit();

			return image;
		}

		public override Bitmap ConvertBack(ImageSource value)
		{
			throw new NotSupportedException();
		}
	}
}
