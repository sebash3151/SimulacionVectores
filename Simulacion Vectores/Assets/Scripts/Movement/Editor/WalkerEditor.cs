using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Walker))]
public class WalkerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Manual Update"))
        {
            Walker myWalker = target as Walker;
            myWalker.UpdatePosition();
        }
    }
}
