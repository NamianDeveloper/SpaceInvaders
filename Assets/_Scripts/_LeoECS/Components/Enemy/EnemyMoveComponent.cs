using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct EnemyMoveComponent
    {
        public Transform Transform;
        public float MoveSpeed;
    }
}