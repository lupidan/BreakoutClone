using UnityEngine;

namespace Game
{
    public interface GameController
    {

        bool AreAllBlocksDestroyed { get; }

        void AddPoints(int points);
        void GoToNextLevel();
        void SubstractLife();
    }
}

