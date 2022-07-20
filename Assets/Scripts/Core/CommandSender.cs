using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestHands
{
    public class CommandSender : MonoBehaviour
    {
        [SerializeField] private Button _runButton;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private DeviceManager _manager;

        private void Awake()
        {
            _runButton.onClick.AddListener(RunCommand);
        }

        private void RunCommand()
        {
            string command = _inputField.text;
            string[] args = command.Split(' ');
            switch (args[0])
            {
                case "new":
                    var startState = new Vector3(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]));
                    
                    var deviceInfo = new DeviceInfo();
                    deviceInfo.Id = Convert.ToInt32(args[1]);
                    deviceInfo.IsDiscrete = Convert.ToBoolean(args[5]);
                    deviceInfo.HasQueue = Convert.ToBoolean(args[6]);
                    deviceInfo.ThrowsException = Convert.ToBoolean(args[7]);
                    deviceInfo.State = startState;
                    
                    _manager.NewDevice(deviceInfo, startState);
                    break;

                case "change":
                    var id = Convert.ToInt32(args[1]);
                    var newState = new Vector3(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]));
                    _manager.ChangeDeviceState(id, newState);
                    break;

                case "delete":
                    _manager.DeleteDevice(Convert.ToInt32(args[1]));
                    break;
            }
        }

        private void OnDestroy()
        {
            _runButton.onClick.RemoveListener(RunCommand);
        }
    }
}