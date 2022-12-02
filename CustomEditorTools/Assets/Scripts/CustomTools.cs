using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CustomTools : EditorWindow
{
    static float xscale = 0.0f;
    static float yscale = 0.0f;
    static float zscale = 0.0f;

    [MenuItem("Custom Tools/The Best Tools")]
    // The Init function is used to show a new editor window
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(CustomTools));
        window.Show();
    }

    bool sizeObject; 
    
    void OnGUI()
    {
        // can we resize the object?
        sizeObject = EditorGUILayout.Toggle("Resize Object?", sizeObject);

        // write a header
        EditorGUILayout.LabelField("Resize Selected Object", EditorStyles.boldLabel);
        // show our sliders
        xscale = EditorGUILayout.Slider(xscale, 1, 100);
        yscale = EditorGUILayout.Slider(yscale, 1, 100);
        zscale = EditorGUILayout.Slider(zscale, 1, 100);

        // time since editor start
        EditorGUILayout.LabelField("Editor Session Time: ", Time.time.ToString(), EditorStyles.boldLabel);        
        // our fps
        EditorGUILayout.LabelField("Editor FPS: ", ((int)1f /Time.deltaTime).ToString(), EditorStyles.boldLabel);

        // button
        EditorGUILayout.LabelField("Button Examples", EditorStyles.boldLabel);

        if (GUILayout.Button("Randomly Rotate Object"))
        {
            // randomly rotate our current object
            Selection.activeTransform.eulerAngles = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        }

        if (GUILayout.Button("Reset Object Rotation"))
        {
            // randomly rotate our current object
            Selection.activeTransform.eulerAngles = Vector3.zero;
        }
        
        if (GUILayout.Button("Create Camera from View"))
        {
            // find our object in space
            Quaternion camRot = SceneView.lastActiveSceneView.rotation;
            Vector3 camPos = SceneView.lastActiveSceneView.camera.transform.position;
            // create a new camera in that position
            Camera ourCam = Instantiate(new GameObject(), camPos, camRot).AddComponent<Camera>();
            // remove extra object
            DestroyImmediate(GameObject.Find("New Game Object"));

            ourCam.fieldOfView = SceneView.lastActiveSceneView.camera.fieldOfView;
            ourCam.gameObject.name = "Custom Created Camera";
        }
                
        if (GUILayout.Button("Look At Selected Object"))
        {
            SceneView.lastActiveSceneView.LookAt(Selection.activeTransform.position);
        }

        Repaint();
    }

    void OnInspectorUpdate()
    {
        if (Selection.activeTransform && sizeObject)
            Selection.activeTransform.localScale = new Vector3(xscale, yscale, zscale);
    }
}