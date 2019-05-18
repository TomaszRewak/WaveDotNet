using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WaveDotNet.Designer.ViewModels.Tree;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveDotNet.Designer.ViewModels.WaveDesigner.Helpers
{
	internal class FileHelper
	{
		private readonly SerializationHelper _serializationHelper;

		public FileHelper(SerializationHelper serializationHelper)
		{
			_serializationHelper = serializationHelper;
		}

		public void Save(WaveDesignerViewModel waveDesigner)
		{
			if (!AskUserToSave(out string fileName))
				return;

			var fileContent = ConvertToJson(waveDesigner);

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

		private string ConvertToJson(WaveDesignerViewModel waveDesigner)
		{
			var payload = _serializationHelper.Serialize(waveDesigner);

			return JsonConvert.SerializeObject(payload, Formatting.Indented);
		}

		public void Load(WaveDesignerViewModel viewModel)
		{
			if (!AskUserToLoad(out string fileName))
				return;

			var fileContent = File.ReadAllText(fileName);

			ReadFromJson(viewModel, fileContent);
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

		private void ReadFromJson(WaveDesignerViewModel waveDesigner, string json)
		{
			dynamic value = JObject.Parse(json);

			_serializationHelper.Deserialize(waveDesigner, value);
		}
	}
}
