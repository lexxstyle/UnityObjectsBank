using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class TextureBank : LinkBank
{
    [SerializeField] private Texture2D[] m_Textures;
    
    public Texture2D[] textures
    {
        get { return m_Textures; }
        set { m_Textures = value; }
    }

    public override void Refresh(string[] objectsGUID)
    {
#if UNITY_EDITOR
        textures = new Texture2D[objectsGUID.Length];
        int i = 0;
        foreach (string guid in objectsGUID)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));

            Texture2D _obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), ConvertToType(unityObjectType)) as Texture2D;
            textures[i] = _obj;
            i++;
        }
#endif
    }
}
