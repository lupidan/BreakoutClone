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
/// A Ball component implements the behaviour of a ball for the Game.
/// Initially the ball needs to be launched.
/// The Ball conforms to the PoolableComponent, making it suitable to interact with a GameObjectPool.
/// </summary>
public class Ball : MonoBehaviour, PoolableComponent {

    enum BounceSide
    {
        Right,
        Top,
        Left,
        Bottom
    }

    /// <summary>
    /// The GameObject tag that all Ball elements should have.
    /// </summary>
    public static string Tag = "Ball";

    /// <summary>
    /// Whether the ball is on the playfield or not. Initially is false.
    /// </summary>
    public bool isOnPlay { get; private set; }
    
    private Rigidbody2D rigidBody2D = null;
    private bool destroyedABlock = false;

    void Awake()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        destroyedABlock = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!destroyedABlock && collision.gameObject.tag == Block.Tag)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            DidHitBlock(block, collision);

            GameObjectController gameObjectController = Toolbox.GameObjectController;
            GameController gameController = Toolbox.GameController;
            gameObjectController.DestroyBlock(block);
            gameController.AddPoints(block.points);
            if (gameObjectController.gameBlocks.Count == 0)
            {
                gameController.GoToNextLevel();
            }
            destroyedABlock = true;
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Block.Tag)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            DidHitBlock(block, null);
        }
    }*/

    /// <summary>
    /// Launches the ball in a 45 degree angle with a specific speed.
    /// </summary>
    /// <param name="speed">The speed value to launch the Ball.</param>
    public void Launch(float speed)
    {
        transform.parent = null;
        Vector3 direction = new Vector3(1.0f, 1.0f, 0.0f);
        rigidBody2D.velocity = direction.normalized * speed;
        isOnPlay = true;
    }

    private BounceSide BounceSideForAngle(float angle)
    {
        float calcAngle = 26.565051177143886f;
        if (angle < -calcAngle)
            angle += 360.0f;
        else if (angle > 360.0f - calcAngle)
            angle -= 360.0f;

        angle -= calcAngle * 2;
        if (angle < 0.0f)
        {
            return BounceSide.Right;
        }

        angle -= 360.0f - calcAngle - calcAngle;
        if (angle < 0.0f)
        {
            return BounceSide.Top;
        }

        angle -= calcAngle * 2;
        if (angle < 0.0f)
        {
            return BounceSide.Left;
        }

        return BounceSide.Bottom;
    }

    private void DidHitBlock(Block block, Collider2D collider2D)
    {
        Vector3 angleVector = transform.position - block.transform.position;
        float angle = Mathf.Atan2(angleVector.y, angleVector.x) * Mathf.Rad2Deg;
        Vector3 velocity = rigidBody2D.velocity;
        switch (BounceSideForAngle(angle))
        {
            case BounceSide.Left:
            case BounceSide.Right:
                velocity.x = -velocity.x;
                break;
            case BounceSide.Bottom:
            case BounceSide.Top:
                velocity.y = -velocity.y;
                break;
        }
        rigidBody2D.velocity = velocity;
        Debug.Log("ANGLE " + angle);
    }

    // PoolableObject implementation
    public void OnSpawn()
    {
        isOnPlay = false;
    }

    public void OnDespawn()
    {
        isOnPlay = false;
    }
}
