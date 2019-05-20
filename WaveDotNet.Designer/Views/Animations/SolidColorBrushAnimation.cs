using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WaveDotNet.Designer.Views.Animations
{
	internal class SolidColorBrushAnimation : AnimationTimeline
	{
		public override Type TargetPropertyType => throw new NotImplementedException();

		protected override Freezable CreateInstanceCore()
		{
			throw new NotImplementedException();
		}
	}
}
