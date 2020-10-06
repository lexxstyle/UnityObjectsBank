using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class SpriteBank : LinkBank
{
    [SerializeField] private Sprite[] m_Sprites;
    
    public Sprite[] sprites
    {
        get { return m_Sprites; }
        set { m_Sprites = value; }
    }

    public override void Refresh(string[] objectsGUID)
    {
#if UNITY_EDITOR
        sprites = new Sprite[objectsGUID.Length];
        int i = 0;
        foreach (string guid in objectsGUID)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));

            Sprite _obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), ConvertToType(unityObjectType)) as Sprite;
            sprites[i] = _obj;
            i++;
        }
#endif
    }
}
