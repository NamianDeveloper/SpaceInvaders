using Leopotam.Ecs;
using UnityEngine;

namespace Voody.UniLeo
{
    public class EntityObject : MonoBehaviour
    {
        private EcsEntity? entity;

        public void Set(EcsEntity? entity)
        {
            this.entity = entity;
        }

        public EcsEntity GetEntity() => entity.Value;
    }
}