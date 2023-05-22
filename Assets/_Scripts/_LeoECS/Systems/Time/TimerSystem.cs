using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class TimerSystem : IEcsRunSystem
    {
        private EcsFilter<CooldownComponent> filter = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var cooldownComponent = ref filter.Get1(i);

                if (!cooldownComponent.IsStop)
                    cooldownComponent.CurrentValue -= Time.deltaTime;
            }
        }
    }
}