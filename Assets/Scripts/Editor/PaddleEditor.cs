using UnityEngine;
using UnityEditor;

namespace Game
{
    [CustomEditor(typeof(NormalPaddleComponent))]
    public class NewBehaviourScript : Editor
    {
        [DrawGizmo(GizmoType.Selected)]
        static void DrawPlayArea(NormalPaddleComponent paddleComponent, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            paddleComponent.paddle.MoveArea.DrawGizmo();
        }
    }
}


