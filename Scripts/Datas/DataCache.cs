using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/CacheData", fileName = "DataCache", order = 0)]
public class DataCache : SerializedScriptableObject
{
    public Dictionary<string, AudioClip> listAudioClip;
}
