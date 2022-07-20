using UnityEngine;

namespace TestHands
{
    public interface IDeviceHandler
    {
        public void SetDeviceInfo(DeviceInfo info);

        public void AddAction(Vector3 action);

        public void Run();

        public void Delete();
    }
}