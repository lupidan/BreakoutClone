using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class DefaultBlock : Block
    {
        [SerializeField]
        private int points = 100;
        public GameEntity gameEntity;

        public int Points { get { return points; } }

        public void Destroy()
        {
            gameEntity.Destroy();
        }

    }
}

