using UnityEditor;

namespace Tools
{
    [CustomEditor(typeof(TextArea)), CanEditMultipleObjects]
    public class TextAreaEditor : Editor
    {

        public SerializedProperty longStringProp;

        void OnEnable()
        {
            longStringProp = serializedObject.FindProperty("longString");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            longStringProp.stringValue = EditorGUILayout.TextArea(longStringProp.stringValue);
            serializedObject.ApplyModifiedProperties();
        }
    }
}