using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        public EcsFilter<PlayerMoveComponent> filter = null;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref PlayerMoveComponent playerMoveComponent = ref filter.Get1(i);
                
                Vector3 move = playerMoveComponent.JoystickMovement.ReturnVectorDirection();
                
                playerMoveComponent.Rigidbody2D.velocity =
                    (move * playerMoveComponent.MoveSpeed);
            }
        }
    }
}