using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EnemyMoveSystem : IEcsRunSystem
    {
        public EcsFilter<EnemyMoveComponent, CooldownComponent> filter = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref EnemyMoveComponent enemyMoveComponent = ref filter.Get1(i);
                ref CooldownComponent cooldownComponent = ref filter.Get2(i);
                
                enemyMoveComponent.Transform.Translate(Vector2.right * enemyMoveComponent.MoveSpeed * Time.deltaTime);

                if (cooldownComponent.CurrentValue <= 0)
                {
                    enemyMoveComponent.Transform.position -= new Vector3(0, 0.25f, 0);
                    cooldownComponent.CurrentValue = cooldownComponent.CooldownTime;
                }
            }
        }
    }
}