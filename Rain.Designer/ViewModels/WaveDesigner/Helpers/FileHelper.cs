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
			if (!AskUserToSave(out string fileName))
				return;

			var fileContent = ConvertToJson(nodes);

			File.WriteAllText(fileName, fileContent);
		}

		private bool AskUserToSave(out string fileName)
		{
			var saveFileDialog = new SaveFileDialog();

			switch (saveFileDialog.ShowDialog())
			{
				case DialogResult.OK:
					fileName = saveFileDialog.FileName;
					return true;
				default:
					fileName = null;
					return false;
			}
		}

		private string ConvertToJson(IReadOnlyCollection<NodeViewModel> nodes)
		{
			var payload = new
			{
				Nodes = nodes.Select(node => node.Serialize())
			};

			return JsonConvert.SerializeObject(payload, Formatting.Indented);
		}

		public bool Load(out IReadOnlyCollection<NodeViewModel> nodes)
		{
			nodes = null;

			if (!AskUserToLoad(out string fileName))
				return false;

			var fileContent = File.ReadAllText(fileName);

			nodes = ConvertFromJson(fileContent);

			return true;
		}

		private bool AskUserToLoad(out string fileName)
		{
			var openFileDialog = new OpenFileDialog();

			switch (openFileDialog.ShowDialog())
			{
				case DialogResult.OK:
					fileName = openFileDialog.FileName;
					return true;
				default:
					fileName = null;
					return false;
			}
		}

		public IReadOnlyCollection<NodeViewModel> ConvertFromJson(string json)
		{
			dynamic value = JObject.Parse(json);

			return (value.Nodes as IEnumerable<dynamic>).Select(nodeDescription =>
			{
				var node = _nodeFactory();
				node.Deserialize(nodeDescription);
				return node;
			}).ToList();
		}
	}
}
