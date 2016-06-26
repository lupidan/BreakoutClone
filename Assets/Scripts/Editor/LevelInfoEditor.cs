using UnityEngine;
using UnityEditor;

public class LevelInfoEditor : MonoBehaviour {

    private static string DefaultLevelName = "NewLevel.lvl";

    [MenuItem("Assets/Create/Level")]
    public static void CreateMyAsset()
    {
        LevelInfo asset = ScriptableObject.CreateInstance<LevelInfo>();
        if (!AssetDatabase.IsValidFolder("Assets/Levels"))
        {
            AssetDatabase.CreateFolder("Assets", "Levels");
        }
        AssetDatabase.CreateAsset(asset, "Assets/Levels/NewLevel.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
