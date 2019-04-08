using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Samples
{
	internal class SamplesViewModel : ViewModel
	{
		private readonly Func<SampleViewModel> _sampleFactory;

		public SamplesViewModel(Func<SampleViewModel> sampleFactory)
		{
			_sampleFactory = sampleFactory;
		}

		private IReadOnlyCollection<SampleViewModel> _samples = new List<SampleViewModel>();
		public IReadOnlyCollection<SampleViewModel> Samples
		{
			get => _samples;
			set => Set(ref _samples, value);
		}

		private void AddSample()
		{
			var newSample = _sampleFactory();

			this.Samples = this
				.Samples
				.Concat(new[] { newSample })
				.ToList();
		}

		private void RemoveSample(SampleViewModel sample)
		{
			this.Samples = this
				.Samples
				.Except(new[] { sample })
				.ToList();
		}

		public ICommand AddSampleCommand => new Command(AddSample);
		public ICommand RemoveSampleCommand => new Command<SampleViewModel>(RemoveSample);
	}
}
