using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestHands
{
    public class CommandSender : MonoBehaviour
    {
        [SerializeField] private Button runButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private DeviceManager manager;

        private void Awake()
        {
            runButton.onClick.AddListener(RunCommand);
        }

        private void RunCommand()
        {
            string command = inputField.text;
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
                    
                    manager.NewDevice(deviceInfo, startState);
                    break;

                case "change":
                    var id = Convert.ToInt32(args[1]);
                    var newState = new Vector3(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]));
                    manager.ChangeDeviceState(id, newState);
                    break;

                case "delete":
                    manager.DeleteDevice(Convert.ToInt32(args[1]));
                    break;
            }
        }

        private void OnDestroy()
        {
            runButton.onClick.RemoveListener(RunCommand);
        }
    }
}