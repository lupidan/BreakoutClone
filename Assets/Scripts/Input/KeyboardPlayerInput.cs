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
/// A KeyboardPlayerInput instance implements a PlayerInput interface to be used with a Keyboard.
/// </summary>
public class KeyboardPlayerInput : PlayerInput {

    /// <summary>
    /// The expected horizontal speed in units by second.
    /// </summary>
    public float horizontalSpeed = 7.0f;

    /// <summary>
    /// Creates a KeyboardPlayerInput instance with a specific horizontal speed.
    /// </summary>
    /// <param name="horizontalSpeed"></param>
    public KeyboardPlayerInput(float horizontalSpeed)
    {
        this.horizontalSpeed = horizontalSpeed;
    }

    // PlayerInput interface implementation
    public float UpdateXPosition(float currentXPosition)
    {
        float horizontalAxisMovement = Input.GetAxisRaw("Horizontal");
        return currentXPosition + (horizontalSpeed * horizontalAxisMovement * Time.deltaTime);
    }

    public bool LaunchButtonPressed
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }

    public bool PauseButtonPressed
    {
        get
        {
            return Input.GetButtonDown("Cancel");
        }
    }

    public bool CanUpdateGame
    {
        get
        {
            return true;
        }
    }
}
