using WaveDotNet.Designer.Views.Common;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Plots.Converters
{
	internal class WaveFactoryToWaveConverter : ValueConverter<Func<IWave>, IWave>
	{
		public override IWave Convert(Func<IWave> value)
		{
			return value?.Invoke();
		}

		public override Func<IWave> ConvertBack(IWave value)
		{
			throw new NotSupportedException();
		}
	}
}
