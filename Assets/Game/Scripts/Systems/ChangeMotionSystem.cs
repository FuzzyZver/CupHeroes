using UnityEngine;
using Leopotam.Ecs;

public class ChangeMotionSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<ChangeMotionEvent> _changeMotionEventFilter;
    private EcsFilter<EnemyFlag> _enemyFlagFilter;
    private bool _isPlayerMotion = false;
    
    public void Init()
    {

    }

    public void Run()
    {
        foreach (int i in _changeMotionEventFilter)
        {
            Debug.Log("Battle!");
            if(_enemyFlagFilter.GetEntitiesCount() > 0 && !_isPlayerMotion)
            {
                EcsWorld.NewEntity().Get<PlayerMotionEvent>();
                _isPlayerMotion = true;

            }
            else if(_enemyFlagFilter.GetEntitiesCount() > 0 && _isPlayerMotion)
            {
                _isPlayerMotion = false;
                EcsWorld.NewEntity().Get<EnemiesMotionEvent>();
            }
            else if (_enemyFlagFilter.GetEntitiesCount() == 0)
            {
                EcsWorld.NewEntity().Get<EndBattleEvent>();
                SceneData.PlayerOnScene.GetEntity().Get<PlayerMoveFlag>();
            }
        }
    }
}
