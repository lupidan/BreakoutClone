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
using UnityEngine.EventSystems;

public class TouchScreenPlayerInput : PlayerInput
{

    /// <summary>
    /// The expected horizontal speed in units by second.
    /// </summary>
    public float horizontalSpeed = 7.0f;

    /// <summary>
    /// Creates a KeyboardPlayerInput instance with a specific horizontal speed.
    /// </summary>
    /// <param name="horizontalSpeed"></param>
    public TouchScreenPlayerInput(float horizontalSpeed)
    {
        this.horizontalSpeed = horizontalSpeed;
    }

    // PlayerInput interface implementation
    public float UpdateXPosition(float currentXPosition)
    {
        int numberOfTouches = Input.touchCount;
        bool rightPressed = false;
        bool leftPressed = false;

        for (int i = 0; i < numberOfTouches; i++)
        {
            Touch touch = Input.touches[i];
            if (touch.position.x > Screen.width / 2.0f)
            {
                rightPressed = true;
            }
            else
            {
                leftPressed = true;
            }
        }

        float xAxis = (rightPressed ? 1.0f : 0.0f) + (leftPressed ? -1.0f : 0.0f);
        return currentXPosition + (horizontalSpeed * xAxis * Time.deltaTime);
    }

    public bool LaunchButtonPressed
    {
        get
        {
            // On touch, we can only launch with the GUI button
            return false;
        }
    }

    public bool PauseButtonPressed
    {
        get
        {
            // On touch, we can only pause with the GUI button
            return false;
        }
    }

    public bool CanUpdateGame
    {
        get
        {
            return EventSystem.current.currentSelectedGameObject == null;
        }
    }

}
