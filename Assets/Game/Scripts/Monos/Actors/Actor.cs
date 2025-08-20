using UnityEngine;
using Leopotam.Ecs;

public abstract class Actor : MonoBehaviour
{
    private EcsEntity _entity;
    public void Init(EcsWorld world)
    {
        EcsEntity entity = world.NewEntity();
        _entity = entity;
        ExpandEntity(entity);
    }

    public abstract void ExpandEntity(EcsEntity entity);

    public EcsEntity GetEntity() { return _entity; }
}
