using UnityEngine;
using Leopotam.Ecs;

public class EcsInclude : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private UI _ui;
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems
            //.Add(new...

            //.OneFrame<...

            .Inject(_world)
            .Inject(_gameConfig)
            .Inject(_sceneData)
            .Inject(_ui)

            .Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
