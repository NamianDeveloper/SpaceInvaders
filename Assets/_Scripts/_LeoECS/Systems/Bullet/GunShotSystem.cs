using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GunShotSystem : IEcsRunSystem
    {
        public EcsFilter<GunShotComponent, CooldownComponent> filter = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref GunShotComponent gunShotComponent = ref filter.Get1(i);
                ref CooldownComponent cooldownComponent = ref filter.Get2(i);

                if (cooldownComponent.CurrentValue <= 0)
                {
                    if (gunShotComponent.Transform == null)
                    {
                        filter.GetEntity(i).Destroy();
                        continue;
                    }

                    float randomValue = Random.Range(0, 1f);
                    if (randomValue <= gunShotComponent.ShotChance)
                    {
                        MonoBehaviour.Instantiate(gunShotComponent.BulletPrefubs[Random.Range(0, gunShotComponent.BulletPrefubs.Length)],
                            gunShotComponent.Transform.position,
                            gunShotComponent.Transform.rotation);

                        if (gunShotComponent.SoundAudio)
                        {
                            gunShotComponent.SoundAudio.pitch = Random.Range(0.9f, 1.1f);
                            gunShotComponent.SoundAudio.Play();
                        }
                    }

                    cooldownComponent.CurrentValue = cooldownComponent.CooldownTime;
                }
            }
        }
    }
}