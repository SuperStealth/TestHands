using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestHands
{
    public class JsonDeserializer
    {
        private const string fileName = "json.json";
        public DeviceInfo[] Deserialize()
        {
            var param = JsonHelper.FromJson<DeviceInfo>("{\"Items\":[{\"Id\":1, \"IsDiscrete\":true, \"HasQueue\":true, \"ThrowsException\":true, \"State\":{\"x\":15, \"y\":25, \"z\":35}}]}");
            return param;
        }
    }
}

