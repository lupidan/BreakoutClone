///
/// The MIT License(MIT)
/// 
/// Copyright(c) 2016 Daniel Lupiañez Casares
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
///

using UnityEngine;

/// <summary>
/// A delegate type that defines an event happening in a Block component.
/// </summary>
/// <param name="block">The Block component where the event happened.</param>
public delegate void BlockEvent(Block block);

/// <summary>
/// A Block component implements the behaviour of a block for the Game.
/// The Block conforms to the PoolableComponent, making it suitable to interact with a GameObjectPool.
/// </summary>
public class Block : MonoBehaviour, PoolableComponent {

    /// <summary>
    /// The GameObject tag that all Block elements should have.
    /// </summary>
    public static string Tag = "Block";

    /// <summary>
    /// Event called when the Block's GameObject is destroyed.
    /// </summary>
    public event BlockEvent OnBlockDestroyed;

    /// <summary>
    /// The amount of points this block is worth.
    /// </summary>
    public int points = 100;

    /// <summary>
    /// The main sprite renderer of the Block Game Object.
    /// </summary>
    public SpriteRenderer spriteRenderer { get; private set; }

    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // PoolableObject implementation
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
