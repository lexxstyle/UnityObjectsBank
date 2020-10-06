using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PrefabsBank : LinkBank
{
    [SerializeField] private GameObject[] m_Prefabs;
    
    public GameObject[] prefabs
    {
        get { return m_Prefabs; }
        set { m_Prefabs = value; }
    }

    public override void Refresh(string[] objectsGUID)
    {
#if UNITY_EDITOR
        prefabs = new GameObject[objectsGUID.Length];
        int i = 0;
        foreach (string guid in objectsGUID)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));

            GameObject _obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), ConvertToType(unityObjectType)) as GameObject;
            prefabs[i] = _obj;
            i++;
        }
#endif
    }
}
