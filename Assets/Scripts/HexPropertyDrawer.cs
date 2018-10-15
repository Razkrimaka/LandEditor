using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(HexCoordinates))]
public class HexPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        HexCoordinates coords = new HexCoordinates(property.FindPropertyRelative("_x").intValue,
               property.FindPropertyRelative("_z").intValue);
        position = EditorGUI.PrefixLabel(position, label);
        GUI.Label(position, coords.ToString());
    }
}
