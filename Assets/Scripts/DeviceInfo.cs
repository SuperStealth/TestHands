using System;
using UnityEngine;

namespace TestHands
{
    [Serializable]
    public class DeviceInfo
    {
        public int Id;

        public bool IsDiscrete;

        public bool HasQueue;

        public bool ThrowsException;

        public Vector3 State;
    }
}

