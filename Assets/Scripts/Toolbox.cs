using UnityEngine;
using System.Collections;

namespace Game
{
    public class Toolbox : MonoBehaviour
    {
        public static Toolbox _instance = null;

        public static Toolbox Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Toolbox>();
                }
                return _instance;
            }
        }

        public static GameController GameController { get { return Instance.gameController; } }
        public static EntityFactory EntityFactory { get { return Instance.entityFactory; } }

        [SerializeField]
        private DefaultGameController gameController = null;

        [SerializeField]
        private DefaultEntityFactory entityFactory = null;

    }
}

