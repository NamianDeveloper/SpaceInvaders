using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct BulletComponent
    {
        public Transform Transform;
        public Vector2 MoveTo;

        public float speed;
    }
}