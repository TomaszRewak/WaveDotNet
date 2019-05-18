using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Markups
{
	internal class MultiplyDouble : MarkupExtension
	{
		public double A { get; set; }
		public double B { get; set; }

		public MultiplyDouble() { }
		public MultiplyDouble(double a, double b)
		{
			A = a;
			B = b;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return A * B;
		}
	}
}
