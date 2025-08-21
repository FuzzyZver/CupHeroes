using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

public class LevelMoveSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    private Vector2 _rightPoint = new Vector2(25, 1);
    private Vector2 _leftPoint = new Vector2(-23, 1);
    private List<Transform> _bgTransform = new List<Transform>();
    private float _levelMoveTime;
    private float _levelSpeed;

    public void Init()
    {
        _bgTransform.Add(GameObject.Instantiate(GameConfig.LevelConfig.Background, _leftPoint, Quaternion.identity).GetComponent<Transform>());
        _bgTransform.Add(GameObject.Instantiate(GameConfig.LevelConfig.Background, new Vector2(1f,1), Quaternion.identity).GetComponent<Transform>());
        _levelMoveTime = GameConfig.LevelConfig.LevelMoveTime;
        _levelSpeed = GameConfig.LevelConfig.LevelSpeed;
    }

    public void Run()
    {
        var player = SceneData.PlayerOnScene.GetEntity();
        if (player.Has<PlayerMoveFlag>())
        {
            if(_levelMoveTime > 0)
            {
                foreach(Transform bg in _bgTransform)
                {
                    if(bg.position.x <= _leftPoint.x +0.1f)
                    {
                        bg.position = _rightPoint;
                    }
                    else
                    {
                        bg.Translate(new Vector2(-1, 0) * _levelSpeed * Time.deltaTime);
                    }
                }
                _levelMoveTime--;
            }
            else if (_levelMoveTime <= 0)
            {
                _levelMoveTime = GameConfig.LevelConfig.LevelMoveTime;
                player.Del<PlayerMoveFlag>();
                EcsWorld.NewEntity().Get<ChangeMotionEvent>();
            }
        }
    }
}
