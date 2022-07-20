using System.IO;

namespace TestHands
{
    public class JsonDeserializer
    {
        private const string FileName = "json.json";
        public DeviceInfo[] Deserialize()
        {
            var json = File.ReadAllText(FileName);
            var param = JsonHelper.FromJson<DeviceInfo>(json);
            return param;
        }
    }
}