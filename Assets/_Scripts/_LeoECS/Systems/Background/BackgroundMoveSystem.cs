using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class BackgroundMoveSystem : IEcsRunSystem
    {
        public EcsFilter<BackgroundMoveComponent> filter = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref BackgroundMoveComponent backgroundMoveComponent = ref filter.Get1(i);

                backgroundMoveComponent.Transform.Translate(Vector3.down * backgroundMoveComponent.MoveSpeed * Time.deltaTime);

                if (backgroundMoveComponent.Transform.position.y < -14)
                {
                    backgroundMoveComponent.Transform.position += new Vector3(0, 26);
                }
            }
        }
    }
}