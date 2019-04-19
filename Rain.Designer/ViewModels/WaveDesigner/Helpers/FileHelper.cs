using Rain.Serialization;
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
		public void Save(IWave wave)
		{
			var saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			var fileContent = WaveSerializer.Serialize(wave);

			File.WriteAllText(saveFileDialog.FileName, fileContent);
		}

		public bool Load(out IWave wave)
		{
			wave = null;

			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return false;

			var fileContent = File.ReadAllText(openFileDialog.FileName);

			wave = WaveSerializer.Deserialize(fileContent);

			return true;
		}
	}
}
