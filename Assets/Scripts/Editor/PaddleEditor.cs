using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaddleComponent))]
public class NewBehaviourScript : Editor
{
    [DrawGizmo(GizmoType.Selected)]
    static void DrawPlayArea(PaddleComponent paddle, GizmoType gizmoType)
    {
        Gizmos.color = Color.red;
        paddle.MoveArea.DrawGizmo();
    }
}
