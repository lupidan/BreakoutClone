using System;
using UnityEngine;

public delegate void BlockEvent(Block block);

public class Block : MonoBehaviour, PoolableComponent {

    public static string Tag = "Block";

    public SpriteRenderer spriteRenderer { get; private set; }
    public int addedScore = 100;

    public event BlockEvent OnBlockDestroyed;

    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSpawn()
    {
        OnBlockDestroyed = null;
    }

    public void OnDespawn()
    {
        if (OnBlockDestroyed != null)
        {
            OnBlockDestroyed(this);
            OnBlockDestroyed = null;
        }
    }
}
