using Newtonsoft.Json;
using Rain.Wave;
using System;

namespace Rain.Serialization
{
	public static class WaveSerializer
	{
		private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto
		};

		public static string Serialize(IWave wave)
		{
			return JsonConvert.SerializeObject(new SerializableWave { Root = wave }, _settings);
		}

		public static IWave Deserialize(string value)
		{
			return JsonConvert.DeserializeObject<SerializableWave>(value, _settings).Root;
		}
	}
}
