using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game Config")]
public class GameConfig : ScriptableObject
{
    public PlayerConfig PlayerConfig;
    public LevelConfig LevelConfig;
}
