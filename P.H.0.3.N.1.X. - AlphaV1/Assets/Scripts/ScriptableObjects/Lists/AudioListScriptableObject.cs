using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioList", menuName = "Scriptable Objects/Lists/Audio List")]
public class AudioListScriptableObject : ScriptableObject
{
    public List<AudioDataScriptableObject> audioDatas = new List<AudioDataScriptableObject>();
}