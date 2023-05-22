using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct PlayerMoveComponent
    {
        public Transform Transform;
        public Rigidbody2D Rigidbody2D;
        public JoystickMovement JoystickMovement;

        [Header("Value")] 
        public float MoveSpeed;
    }
}