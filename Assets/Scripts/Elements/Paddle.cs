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
/// A Paddle component that implements the behaviour of a paddle in the game.
/// </summary>
public class Paddle: MonoBehaviour {

    /// <summary>
    /// The speed the ball is bounced up when colliding with the paddle, or when it's first launched.
    /// </summary>
    public float launchSpeed = 7.0f;

    /// <summary>
    /// This factor controls the direction in which the ball bounces relative to the center of the Paddle.
    /// A value of 0 means the ball always bounces up.
    /// </summary>
    public float bounceCorrectFactor = 0.5f;

    /// <summary>
    /// The move area this component's GameObject is allowed to move in.
    /// The area is highlighted when the paddle is selected in the editor.
    /// </summary>
    public Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Ball.Tag)
        {
            Rigidbody2D rigidBody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody2D != null)
            {
                Vector3 newDirection = collision.gameObject.transform.position - gameObject.transform.position;
                newDirection.x = newDirection.x * bounceCorrectFactor;
                newDirection.z = 0.0f;
                rigidBody2D.velocity = newDirection.normalized * launchSpeed;
            }
        }
    }

    /// <summary>
    /// Updates the X position of the paddle.
    /// </summary>
    /// <param name="xPosition">The new x position of the paddle.</param>
    public void UpdateXPosition(float xPosition)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = xPosition;
        transform.position = moveArea.ClampPosition(newPosition);
    }

}
