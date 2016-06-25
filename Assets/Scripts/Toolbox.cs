using UnityEngine;
using System.Collections;

public class Toolbox : MonoBehaviour {

    private static Toolbox _instance = null;
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
    public static GameObjectController GameObjectController { get { return Instance.gameObjectController; } }

    public GameController gameController = null;
    public GameObjectController gameObjectController = null;

}
