using System.Collections;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class AutoSave
{
    private static float autosaveIntervall = 180;

    private static float m_LastEditorUpdateTime;
    [MenuItem("File/Save project %&s")]
    static void FunctionForceSaveProyect()
    {
        EditorApplication.ExecuteMenuItem("File/Save Project");
        Debug.Log("Saved project");
    }

    //save not only the scene, but the entire project
    [MenuItem("File/Save Scene And Project %#&s")]
    static void FunctionForceSaveSceneAndProyect()
    {
        EditorApplication.ExecuteMenuItem("File/Save");
        EditorApplication.ExecuteMenuItem("File/Save Project");
        Debug.Log("Saved scene and project");
    }

    //initialize script and subscribe for editor update
    static AutoSave()
    {
        m_LastEditorUpdateTime = Time.realtimeSinceStartup;
        EditorApplication.update += OnEditorUpdate; 
    }
           
    
    static void OnEditorUpdate()
    {
        float currentTime = Time.realtimeSinceStartup;
        if (currentTime - m_LastEditorUpdateTime >= autosaveIntervall)
        {
            m_LastEditorUpdateTime = currentTime;
            //do not try to save the project during playmode
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                FunctionForceSaveSceneAndProyect();
            }
                 
        }
    }
        
}