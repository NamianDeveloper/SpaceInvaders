using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class WaveSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyHealthComponent> filter;
        private EcsFilter<UIComponent> scoreFilter;
        public void Run()
        {
            if (0 == filter.GetEntitiesCount())
            {
                ref UIComponent scoreComponent = ref scoreFilter.Get1(0);

                MonoBehaviour.Instantiate(scoreComponent.EnemyParent, new Vector3(0, -0.6f, 0), new Quaternion());

                scoreComponent.CurrentWave++;
                scoreComponent.WaveText.text = scoreComponent.CurrentWave.ToString();
            }
        }
    }
}