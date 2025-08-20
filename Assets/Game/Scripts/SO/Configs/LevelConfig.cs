using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Level Config")]
public class LevelConfig : ScriptableObject
{
    public float WavesCount;
    public float LevelMoveTime;
    public float LevelSpeed;
    public GameObject Background;
}
