using CoreGames.GameName;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CombinationSO))]
public class CombinationSOEditor : Editor
{
    private SerializedProperty boolRowsProp;

    private void OnEnable()
    {
        boolRowsProp = serializedObject.FindProperty("boolRows");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(boolRowsProp, true);

        if (boolRowsProp.isExpanded)
        {
            EditorGUI.indentLevel++;

            for (int i = 0; i < boolRowsProp.arraySize; i++)
            {
                SerializedProperty boolRowProp = boolRowsProp.GetArrayElementAtIndex(i);
                SerializedProperty boolsProp = boolRowProp.FindPropertyRelative("bools");
                EditorGUILayout.BeginVertical(GUI.skin.box);

                EditorGUILayout.LabelField($"Bool Row {i}");

                EditorGUILayout.BeginHorizontal();

                for (int j = 0; j < boolsProp.arraySize; j++)
                {
                    EditorGUILayout.PropertyField(boolsProp.GetArrayElementAtIndex(j), GUIContent.none, GUILayout.Width(50));
                }

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.EndVertical();
            }

            EditorGUI.indentLevel--;
        }

        if (GUILayout.Button("Add New Bool Row"))
        {
            CombinationSO combinationSO = (CombinationSO)target;
            combinationSO.boolRows.Add(new CombinationSO.BoolRow());
        }

        serializedObject.ApplyModifiedProperties();
    }
}