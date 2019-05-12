using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Tree.Helpers;
using Rain.Designer.ViewModels.Waves;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Rain.Designer.ViewModels.Tree.Helpers.WaveBlockFactoryHelper;

namespace Rain.Designer.ViewModels.Tree
{
	internal class NodeViewModel : ViewModel, ISerializable
	{
		private readonly WaveBlockFactoryHelper _waveBlockFactoryHelper;
		private readonly WaveBuilderHelper _waveBuilderHelper;
		private readonly WavePlayerHelper _wavePlayerHelper;
		private readonly WaveBlockSerializationHelper _waveBlockSerializationHelper;

		public NodeViewModel(
			WaveBlockFactoryHelper waveBlockFactoryHelper,
			WaveBuilderHelper waveBuilderHelper,
			WavePlayerHelper wavePlayerHelper,
			WaveBlockSerializationHelper waveBlockSerializationHelper)
		{
			_waveBlockFactoryHelper = waveBlockFactoryHelper;
			_waveBuilderHelper = waveBuilderHelper;
			_wavePlayerHelper = wavePlayerHelper;
			_waveBlockSerializationHelper = waveBlockSerializationHelper;
		}

		private void InputChanged(object subTree, PropertyChangedEventArgs args)
		{
			switch (args.PropertyName)
			{
				case nameof(Wave):
					UpdateWave();
					break;
			}
		}

		private void WaveBlockChanged(object subTree, PropertyChangedEventArgs args)
		{
			UpdateWave();
		}

		private IReadOnlyCollection<NodeViewModel> _inputs = new List<NodeViewModel>();
		public IReadOnlyCollection<NodeViewModel> Inputs
		{
			get => _inputs;
			set => Set(ref _inputs, value)
				.ObserveChildren(InputChanged)
				.Then(UpdateWave);
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableWaveBlockFactories
		{
			get => _waveBlockFactoryHelper.AvailableFactories;
		}

		private WaveBlockFactory _waveBlockFactory;
		public WaveBlockFactory WaveBlockFactory
		{
			get => _waveBlockFactory;
			set => Set(ref _waveBlockFactory, value)
				.Then(UpdateWaveBlock);
		}

		private WaveBlockViewModel _waveBlock;
		public WaveBlockViewModel WaveBlock
		{
			get => _waveBlock;
			set => Set(ref _waveBlock, value)
				.Then(UpdateWave)
				.Observe(WaveBlockChanged);
		}

		private IWave _wave;
		public IWave Wave
		{
			get => _wave;
			set => Set(ref _wave, value);
		}

		private Position _position;
		public Position Position
		{
			get => _position;
			set => Set(ref _position, value);
		}

		public void AddInput(NodeViewModel input)
		{
			Inputs = Inputs
				.Concat(new[] { input })
				.ToList();
		}

		public void RemoveInput(int index)
		{
			var inputsBefore = Inputs.Take(index);
			var inputsAfter = Inputs.Skip(index + 1);

			Inputs = inputsBefore
				.Concat(inputsAfter)
				.ToList();
		}

		private void UpdateWaveBlock()
		{
			WaveBlock = WaveBlockFactory.Create();
		}

		private void UpdateWave()
		{
			if (_waveBuilderHelper.CanBuildWave(this))
				Wave = _waveBuilderHelper.BuildWave(this);
			else
				Wave = null;
		}

		private void Play()
		{
			if (Wave == null)
				return;

			_wavePlayerHelper.PlayWave(Wave);
		}

		public dynamic Serialize()
		{
			return _waveBlockSerializationHelper.SerializeNode(this);
		}

		public void Deserialize(dynamic value)
		{
			_waveBlockSerializationHelper.DeserializeNode(this, value);
		}

		public ICommand AddInputCommand => new Command<NodeViewModel>(AddInput);
		public ICommand RemoveInputCommand => new Command<int>(RemoveInput);
		public ICommand PlayCommand => new Command(Play);
	}
}
