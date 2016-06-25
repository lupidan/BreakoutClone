using UnityEngine;

public delegate void BlockEvent(Block block);

public class Block : MonoBehaviour {

    public static string Tag = "Block";

    public SpriteRenderer spriteRenderer { get; private set; }
    public int addedScore = 100;

    public int AddedScore { get {  return addedScore; } }
    public event BlockEvent OnBlockDestroyed;

    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnDestroy()
    {
        if (OnBlockDestroyed != null)
        {
            OnBlockDestroyed(this);
            OnBlockDestroyed = null;
        }
    }
}
