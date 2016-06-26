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
/// A PlayerInputController is a controller that reads the input from a specific player input. And updates the game accordingly.
/// </summary>
public class PlayerInputController : MonoBehaviour {

    /// <summary>
    /// The player input instance this controller should use to update.
    /// </summary>
    public PlayerInput playerInput = null;

    void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld && Input.touchSupported)
        {
            playerInput = new TouchScreenPlayerInput(7.0f);
        }
        else
        {
            playerInput = new KeyboardPlayerInput(7.0f);
        }
    }

    void Update()
    {
        if (playerInput != null)
        {
            Paddle paddle = Toolbox.GameObjectController.gamePaddle;
            Ball ball = Toolbox.GameObjectController.gameBall;

            UpdatePaddlePosition(paddle, playerInput);
            if (paddle != null)
            {
                CheckAndLaunchBall(ball, playerInput, paddle.launchSpeed);
            }
            CheckAndPauseGame(playerInput);
        }
    }

    private void UpdatePaddlePosition(Paddle paddle, PlayerInput playerInput)
    {
        if (paddle != null && playerInput != null)
        {
            float newXPosition = playerInput.UpdateXPosition(paddle.transform.position.x);
            paddle.UpdateXPosition(newXPosition);
        }
    }

    private void CheckAndLaunchBall(Ball ball, PlayerInput playerInput, float launchSpeed)
    {
        if (playerInput != null && playerInput.ActionButtonPressed && ball != null && !ball.isOnPlay)
        {
            ball.Launch(launchSpeed);
        }
    }

    private void CheckAndPauseGame(PlayerInput playerInput)
    {
        if (playerInput != null && playerInput.PauseButtonPressed)
        {
            GameController gameController = Toolbox.GameController;
            if (gameController.IsPaused)
            {
                gameController.ContinueGame();
            }
            else
            {
                gameController.PauseGame();
            }
        }
    }
}
