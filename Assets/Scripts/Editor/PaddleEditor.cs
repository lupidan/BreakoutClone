using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaddleComponent))]
public class NewBehaviourScript : Editor
{
    [DrawGizmo(GizmoType.Selected)]
    static void DrawPlayArea(Paddle paddle, GizmoType gizmoType)
    {
        Gizmos.color = Color.red;
        paddle.moveArea.DrawGizmo();
    }
}
