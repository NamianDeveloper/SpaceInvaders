using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct GunShotComponent
    {
        public Transform Transform;
        public GameObject[] BulletPrefubs;

        public AudioSource SoundAudio;

        [Range(0, 1)] public float ShotChance;
    }
}