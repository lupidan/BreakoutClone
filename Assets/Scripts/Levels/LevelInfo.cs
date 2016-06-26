using UnityEngine;

[System.Serializable]
public class LevelInfo : ScriptableObject {
    public string levelName;

    [Multiline]
    public string blocks;
}
