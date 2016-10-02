using UnityEngine;

namespace Game
{
	/// <summary>
	/// A delegate type defining an event that happens on a GameController
	/// </summary>
	/// <param name="gameController">The game controller where the event happened.</param>
	public delegate void GameControlEvent(GameController gameController);

    public interface GameController
    {
    	int Score { get; }
    	int Lives { get; }
		bool AreAllBlocksDestroyed { get; }

		/// <summary>
    	/// Method called when the score changes.
    	/// </summary>
    	event GameControlEvent OnScoreChanged;

	    /// <summary>
	    /// Method called when the number of lives changes.
	    /// </summary>
	    event GameControlEvent OnLivesChanged;

	    /// <summary>
	    /// Method called when the game status changes.
	    /// </summary>
		event GameControlEvent OnStatusChanged;

	    /// <summary>
	    /// Method called when the level changes.
	    /// </summary>
		event GameControlEvent OnLevelChanged;

		void CreateLevel(string levelData);
		void PlaceBall();
		void PlacePaddle();
		void DestroyPaddle();
		void FinishGame();
        void AddPoints(int points);
        void GoToNextLevel();
        void SubstractLife();
    }
}

