using System;

namespace Client
{
    [Serializable]
    public struct CooldownComponent
    {
        public float CooldownTime;
        public float CurrentValue;
        public bool IsStop;
    }
}