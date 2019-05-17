using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Views.Plots.Converters
{
	internal class SamplesToBitmapConverter : ValueConverter<(double, double)[], Bitmap>
	{
		public int Height { get; set; }
		public Color BackgroundColor { get; set; }

		public override Bitmap Convert((double, double)[] values)
		{
			if (values == null)
				return null;

			var bitmap = PrepareBitmap(values.Length);

			using (Graphics graphics = Graphics.FromImage(bitmap))
				Draw(graphics, values);

			return bitmap;
		}

		private void Draw(Graphics graphics, (double, double)[] values)
		{
			var min = FindMin(values);
			var max = FindMax(values);

			for (int i = 0; i < values.Length; i++)
			{
				var (sampleMin, sampleMax) = values[i];
				
				graphics.DrawLine(Pens.Red,
					i,
					(float)(Height * (sampleMin - min) / (max - min)),
					i,
					(float)(Height * (sampleMax - min) / (max - min)));
			}
		}

		private Bitmap PrepareBitmap(int width)
			=> new Bitmap(width, Height);

		private double FindMin((double, double)[] values)
			=> values.Min(value => value.Item1);

		private double FindMax((double, double)[] values)
			=> values.Max(value => value.Item2);

		public override (double, double)[] ConvertBack(Bitmap value)
		{
			throw new NotImplementedException();
		}
	}
}
