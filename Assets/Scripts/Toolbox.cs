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

    public static GameControl GameControl { get { return Instance.gameControl; } }

    public GameControl gameControl = null;
	
}
