using UnityEngine;
using Leopotam.Ecs;

public class EnemyActor: Actor
{
    public override void ExpandEntity(EcsEntity entity)
    {
        entity.Get<EnemyFlag>();
        entity.Get<GameObjectRef>().GameObject = this.gameObject;
    }
}
