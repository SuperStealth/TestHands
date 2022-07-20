using System.Collections.Generic;
using UnityEngine;

namespace TestHands
{
    public class DeviceManager : MonoBehaviour
    {
        [SerializeField] private DeviceHandler device;

        private Dictionary<int, DeviceHandler> deviceHandlers;

        private void Awake()
        {
            deviceHandlers = new Dictionary<int, DeviceHandler>();
            var jsonDeserializer = new JsonDeserializer();
            var devices = jsonDeserializer.Deserialize();

            foreach(var device in devices)
            {
                NewDevice(device, device.State);
            }
        }

        private void Update()
        {
            foreach (var handler in deviceHandlers)
            {
                handler.Value.Run();
            }
        }

        public void NewDevice(DeviceInfo deviceInfo, Vector3 startState)
        {
            var newDevice = Instantiate(device);
            deviceHandlers.Add(deviceInfo.Id, newDevice);
            newDevice.transform.rotation = Quaternion.Euler(startState);
            newDevice.SetDeviceInfo(deviceInfo);
        }

        public void ChangeDeviceState(int id, Vector3 newState)
        {
            deviceHandlers[id].AddAction(newState);
        }

        public void DeleteDevice(int id)
        {
            var device = deviceHandlers[id];
            deviceHandlers.Remove(id);
            Destroy(device.gameObject);
        }
    }
}