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
		private readonly Func<NodeViewModel> _nodeFactory;

		public FileHelper(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		public void Save(IReadOnlyCollection<NodeViewModel> nodes)
		{
			var saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			var serializedNodes = new
			{
				Nodes = nodes.Select(node => node.Serialize())
			};
			var fileContent = JsonConvert.SerializeObject(serializedNodes, Formatting.Indented);

			File.WriteAllText(saveFileDialog.FileName, fileContent);
		}

		public bool Load(out IReadOnlyCollection<NodeViewModel> nodes)
		{
			nodes = new List<NodeViewModel>();

			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return false;

			var fileContent = File.ReadAllText(openFileDialog.FileName);
			dynamic json = JObject.Parse(fileContent);

			nodes = (json.Nodes as IEnumerable<dynamic>).Select(nodeDescription =>
			{
				var node = _nodeFactory();
				node.Deserialize(nodeDescription);
				return node;
			}).ToList();

			return true;
		}
	}
}
