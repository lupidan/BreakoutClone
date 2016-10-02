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
using System.Collections;

namespace Game {

	public class DefaultGameController : MonoBehaviour, GameController {

		private int score = 0;
		private int lives = 0;

		private void NotifyScoreChange()
	    {
	        if (OnScoreChanged != null)
	        {
	            OnScoreChanged(this);
	        }
	    }

		public void NotifyLivesChange()
	    {
	        if (OnLivesChanged != null)
	        {
	            OnLivesChanged(this);
	        }
	    }

		#region GameController implementation
		public int Score { get { return score; } }
		public int Lives { get { return lives; } }
		public bool AreAllBlocksDestroyed { get { return false; } }
		public event GameControlEvent OnScoreChanged;
		public event GameControlEvent OnLivesChanged;
		public event GameControlEvent OnStatusChanged;
		public event GameControlEvent OnLevelChanged;

		public void CreateLevel(string levelData)
		{
		}

		public void PlaceBall()
		{
		}

		public void PlacePaddle()
		{
		}

		public void DestroyPaddle()
		{
		}

		public void FinishGame()
		{
		}

		public void AddPoints(int points)
		{
			if (points > 0)
			{
				score += points;
				NotifyScoreChange();
			}
		}

		public void GoToNextLevel()
		{
		}

		public void SubstractLife()
		{
			if (lives > 0)
	        {
	            lives -= 1;
	            NotifyLivesChange();
				PlaceBall();
	        }
	        else
	        {
	            DestroyPaddle();
	            FinishGame();
	        }
		}
		#endregion
	}

}