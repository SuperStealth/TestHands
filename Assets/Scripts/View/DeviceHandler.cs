using System.Collections.Generic;
using UnityEngine;

namespace TestHands
{
    public class DeviceHandler : MonoBehaviour, IDeviceHandler
    {
        private const float Speed = 1f;

        private DeviceInfo _deviceInfo;

        private List<Vector3> _actions;
        
        private void Awake()
        {
            _actions = new List<Vector3>();
        }

        public void SetDeviceInfo(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public void AddAction(Vector3 action)
        {
            _actions.Add(action);
        }

        public void Run()
        {
            if (_actions.Count == 0) return;

            if (_actions.Count > 1 && _deviceInfo.ThrowsException)
            {
                _actions.Clear();
                throw new System.Exception($"Действие устройства {_deviceInfo.Id} не успело завершиться");
            }

            if (!_deviceInfo.HasQueue)
            {
                while (_actions.Count > 1)
                {
                    _actions.RemoveAt(0);
                }
            }
            if (_deviceInfo.IsDiscrete)
            {
                transform.rotation = Quaternion.Euler(_actions[0]);
                _actions.RemoveAt(0);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_actions[0].x, _actions[0].y, _actions[0].z), Speed * Time.deltaTime);
                if (transform.rotation == Quaternion.Euler(_actions[0]))
                {
                    _actions.RemoveAt(0);
                }
            }
        }

        public void Delete()
        {
            Destroy(gameObject);
        }
    }
}