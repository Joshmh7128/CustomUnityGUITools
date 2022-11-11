// Editor script that lets you scale the selected GameObject between 1 and 100

using UnityEditor;
using UnityEngine;

public class CustomTools : EditorWindow
{
    static float xscale = 0.0f;
    static float yscale = 0.0f;
    static float zscale = 0.0f;

    [MenuItem("Custom Tools/ExampleTools")]
    // The Init function is used to show a new editor window
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(CustomTools));
        window.Show();
    }

    void OnGUI()
    {
        // write a header
        EditorGUILayout.LabelField("Resize Selected Object", EditorStyles.boldLabel);
        // show our sliders
        xscale = EditorGUILayout.Slider(xscale, 1, 100);
        yscale = EditorGUILayout.Slider(yscale, 1, 100);
        zscale = EditorGUILayout.Slider(zscale, 1, 100);

        // time since editor start
        EditorGUILayout.LabelField("Editor Session Time: ", Time.time.ToString(), EditorStyles.boldLabel);

        Repaint();
    }

    void OnInspectorUpdate()
    {
        if (Selection.activeTransform)
            Selection.activeTransform.localScale = new Vector3(xscale, yscale, zscale);
    }
}