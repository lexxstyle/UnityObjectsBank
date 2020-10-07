using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnityObjectType
{
    Undefined,
    Prefab,
    Texture,
    Sprite,
    Audio,
    JSON
}

public class LinkBank : MonoBehaviour
{
    [SerializeField] protected string m_PathFolder = string.Empty;
    
    
    public virtual void Refresh(string[] objectsGUID) { }
    
    public string pathFolder
    {
        get { return m_PathFolder; }
        set { m_PathFolder = value; }
    }

    public UnityObjectType unityObjectType
    {
        get
        {
            UnityObjectType _objectType = UnityObjectType.Undefined;
            
            if (this.GetType() == typeof(PrefabsBank)) _objectType = UnityObjectType.Prefab;
            if (this.GetType() == typeof(AudioClipsBank)) _objectType = UnityObjectType.Audio;
            if (this.GetType() == typeof(SpriteBank)) _objectType = UnityObjectType.Sprite;
            if (this.GetType() == typeof(TextureBank)) _objectType = UnityObjectType.Texture;
            if (this.GetType() == typeof(JSONBank)) _objectType = UnityObjectType.JSON;

            return _objectType;
        }
    }

    public static string ConvertToString(UnityObjectType value)
    {
        switch (value)
        {
            case UnityObjectType.Prefab:
                return "prefab";
            case UnityObjectType.Sprite:
                return "sprite";
            case UnityObjectType.Audio:
                return "audioClip";
            case UnityObjectType.Texture:
                return "texture2D";
            case UnityObjectType.JSON:
                return "textAsset";
            default:
                return string.Empty;
        }
    }
    
    public static Type ConvertToType(UnityObjectType value)
    {
        switch (value)
        {
            case UnityObjectType.Prefab:
                return typeof(GameObject);
            case UnityObjectType.Sprite:
                return typeof(Sprite);
            case UnityObjectType.Audio:
                return typeof(AudioClip);
            case UnityObjectType.Texture:
                return typeof(Texture2D);
            case UnityObjectType.JSON:
                return typeof(TextAsset);
            default:
                return null;
        }
    }
}
