using Newtonsoft.Json;
using Rain.Designer.ViewModels.Tree;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain.Designer.ViewModels.WaveDesigner.Helpers
{
	internal class FileHelper
	{
		private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto
		};

		public void Save(IReadOnlyCollection<NodeViewModel> nodes)
		{
			var saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			var fileContent = JsonConvert.SerializeObject(nodes, _settings);

			File.WriteAllText(saveFileDialog.FileName, fileContent);
		}

		public bool Load(out IReadOnlyCollection<NodeViewModel> nodes)
		{
			nodes = null;

			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return false;

			var fileContent = File.ReadAllText(openFileDialog.FileName);

			nodes = JsonConvert.DeserializeObject<List<NodeViewModel>>(fileContent, _settings);

			return true;
		}
	}
}
