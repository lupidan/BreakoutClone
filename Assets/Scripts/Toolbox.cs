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

        public GameController gameController = null;
        public PlayerInput playerInput = null;
        public EntityFactory entityFactory = null;

    }
}

