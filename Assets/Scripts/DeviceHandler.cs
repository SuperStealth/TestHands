using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestHands
{
    public class DeviceHandler : MonoBehaviour
    {
        private DeviceInfo deviceInfo;

        private List<Vector3> actions;
        private float speed = 1f;

        private void Awake()
        {
            actions = new List<Vector3>();
        }

        public void SetDeviceInfo(DeviceInfo deviceInfo)
        {
            this.deviceInfo = deviceInfo;
        }

        public int GetId()
        {
            return deviceInfo.Id;
        }

        public void AddAction(Vector3 action)
        {
            actions.Add(action);
        }

        public void Run()
        {
            if (actions.Count == 0) return;

            if (actions.Count > 1 && deviceInfo.ThrowsException)
            {
                actions.Clear();
                throw new System.Exception($"Действие устройства {deviceInfo.Id} не успело завершиться");
            }

            if (!deviceInfo.HasQueue)
            {
                while (actions.Count > 1)
                {
                    actions.RemoveAt(0);
                }
            }
            if (deviceInfo.IsDiscrete)
            {
                transform.rotation = Quaternion.Euler(actions[0]);
                actions.RemoveAt(0);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(actions[0].x, actions[0].y, actions[0].z), speed * Time.deltaTime);
                if (transform.rotation == Quaternion.Euler(actions[0]))
                {
                    actions.RemoveAt(0);
                }
            }

        }
    }
}