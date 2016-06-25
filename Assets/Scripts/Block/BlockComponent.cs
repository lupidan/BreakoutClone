using UnityEngine;

public class BlockComponent : MonoBehaviour, Block {

    public static string Tag = "Block";

    public int addedScore = 100;

    public int AddedScore { get {  return addedScore; } }
    public event BlockEvent OnBlockDestroyed;

    void OnDestroy()
    {
        if (OnBlockDestroyed != null)
        {
            OnBlockDestroyed(this);
            OnBlockDestroyed = null;
        }
    }
}
