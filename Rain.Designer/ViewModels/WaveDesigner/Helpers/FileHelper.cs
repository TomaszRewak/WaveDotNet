using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
		public void Save(IReadOnlyCollection<NodeViewModel> nodes)
		{
			var saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			var serializedNodes = nodes.Select(node => node.Serialize());
			var fileContent = JsonConvert.SerializeObject(serializedNodes, Formatting.Indented);

			File.WriteAllText(saveFileDialog.FileName, fileContent);
		}

		public bool Load(out IReadOnlyCollection<NodeViewModel> nodes)
		{
			nodes = null;

			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return false;

			var fileContent = File.ReadAllText(openFileDialog.FileName);
			dynamic json = JObject.Parse(fileContent);

			//nodes = JObject.Parse(fileContent);

			return true;
		}
	}
}
