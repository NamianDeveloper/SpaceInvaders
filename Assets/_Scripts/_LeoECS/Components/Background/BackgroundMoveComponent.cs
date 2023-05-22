using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct BackgroundMoveComponent
    {
        public Transform Transform;
        public float MoveSpeed;
    }
}