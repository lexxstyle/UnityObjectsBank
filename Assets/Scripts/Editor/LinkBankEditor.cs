using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LinkBank), true)]
public class LinkBankEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LinkBank targetScript = (LinkBank) target;
        
        serializedObject.Update();

        DrawDefaultInspector();
        
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Refresh"))
        {
            string pathFolder = targetScript.pathFolder;
            UnityObjectType unityObjectType = targetScript.unityObjectType;
            
            if (!string.IsNullOrEmpty(pathFolder) && unityObjectType != UnityObjectType.Undefined)
            {
                if (Directory.Exists(Application.dataPath + "/" + pathFolder))
                {
                    string path = "Assets/" + pathFolder;
                    string objectType = "t:" + LinkBank.ConvertToString(unityObjectType);
                    
                    string[] guids2 = AssetDatabase.FindAssets(objectType, new[] {path});
            
                    targetScript.Refresh(guids2);
                    
                }
            }
        }
    }
}
