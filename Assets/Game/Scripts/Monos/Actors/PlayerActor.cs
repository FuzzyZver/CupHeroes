using UnityEngine;
using Leopotam.Ecs;

public class PlayerActor: Actor
{
    [SerializeField] private Transform _transform;

    public override void ExpandEntity(EcsEntity entity)
    {
        entity.Get<TransformRef>().Transform = _transform;
        entity.Get<PlayerMoveFlag>();
    }
}
