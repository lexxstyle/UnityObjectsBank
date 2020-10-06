using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class AudioClipsBank : LinkBank
{
    [SerializeField] private AudioClip[] m_AudioClips;
    
    public AudioClip[] audioClips
    {
        get { return m_AudioClips; }
        set { m_AudioClips = value; }
    }

    public override void Refresh(string[] objectsGUID)
    {
#if UNITY_EDITOR
        audioClips = new AudioClip[objectsGUID.Length];
        int i = 0;
        foreach (string guid in objectsGUID)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));

            AudioClip _obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), ConvertToType(unityObjectType)) as AudioClip;
            audioClips[i] = _obj;
            i++;
        }
#endif
    }
}
