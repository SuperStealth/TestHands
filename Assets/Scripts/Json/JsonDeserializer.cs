using System.IO;

namespace TestHands
{
    public class JsonDeserializer
    {
        private const string fileName = "json.json";
        public DeviceInfo[] Deserialize()
        {
            var json = File.ReadAllText(fileName);
            var param = JsonHelper.FromJson<DeviceInfo>(json);
            return param;
        }
    }
}