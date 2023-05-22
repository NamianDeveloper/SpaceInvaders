using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;
using Voody.UniLeo;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData configuration;
        [SerializeField] private SceneData sceneData;

        EcsWorld _world;

        EcsSystems _systems;
        EcsSystems _fixedUpdateSystems;

        void Start()
        {
            _world = new EcsWorld();

            _systems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();

            AddSystems();
            AddFixedUpdateSystems();

            _systems
                .Init();
            _fixedUpdateSystems
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void AddInjections()
        {
            RuntimeData runtimeData = new RuntimeData();
            _systems
                .Inject(runtimeData);
        }

        private void AddSystems()
        {
            _systems
                //Enemy
                .Add(new EnemyMoveSystem())
                //Bullet
                .Add(new BulletMoveSystem())
                .Add(new GunShotSystem())
                //Wave
                .Add(new WaveSystem())
                //Background
                .Add(new BackgroundMoveSystem())

                //Time
                .Add(new TimerSystem());
        }

        private void AddFixedUpdateSystems()
        {
            _fixedUpdateSystems
                // Player
                .Add(new PlayerMoveSystem());
        }

        private void AddOneFrames()
        {
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}