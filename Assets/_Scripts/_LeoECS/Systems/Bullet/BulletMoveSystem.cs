using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;

namespace Client
{
    sealed class BulletMoveSystem : IEcsRunSystem
    {
        public EcsFilter<BulletComponent> filter = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                BulletComponent bulletMoveComponent = filter.Get1(i);
                
                if (bulletMoveComponent.Transform == null)
                {
                    filter.GetEntity(i).Destroy();
                    continue;
                }

                bulletMoveComponent.Transform.Translate(bulletMoveComponent.MoveTo * bulletMoveComponent.speed * Time.deltaTime);

                if (bulletMoveComponent.Transform.position.y < -7 || bulletMoveComponent.Transform.position.y > 7)
                {
                    MonoBehaviour.Destroy(bulletMoveComponent.Transform.gameObject);
                    filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}