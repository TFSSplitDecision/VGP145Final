using UnityEditor;
using UnityEngine;

/// <summary>
/// Based on the ReadOnly attribute:
/// https://discussions.unity.com/t/how-to-make-a-readonly-property-in-inspector/75448/5
/// 
/// The only difference is that is makes variables readonly only during play mode.
/// This allows devs to edit parameters in the inspector. But they become unchangeable when the game runs.
/// </summary>
public class SceneEditOnlyAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(SceneEditOnlyAttribute))]
public class SceneEditOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if( Application.isPlaying ) GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
