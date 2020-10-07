using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class JSONBank : LinkBank
{
    [SerializeField] private TextAsset[] m_JsonFiles;
    
    public TextAsset[] jsonFiles
    {
        get { return m_JsonFiles; }
        set { m_JsonFiles = value; }
    }

    public override void Refresh(string[] objectsGUID)
    {
#if UNITY_EDITOR
        jsonFiles = new TextAsset[objectsGUID.Length];
        int i = 0;
        foreach (string guid in objectsGUID)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));

            TextAsset _obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), ConvertToType(unityObjectType)) as TextAsset;
            jsonFiles[i] = _obj;
            i++;
        }
#endif
    }
}
