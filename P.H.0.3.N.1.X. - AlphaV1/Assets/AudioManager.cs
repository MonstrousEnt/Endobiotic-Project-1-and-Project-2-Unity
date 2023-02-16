using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundList soundList;

    private void Start()
    {
        for (int i = 0; i < soundList.soundDatas.Count; i++)
        {
            soundList.soundDatas[i].source = gameObject.AddComponent<AudioSource>();

            soundList.soundDatas[i].source.clip = soundList.soundDatas[i].clip;
            soundList.soundDatas[i].source.volume = soundList.soundDatas[i].volume;
            soundList.soundDatas[i].source.pitch = soundList.soundDatas[i].pitch;
            soundList.soundDatas[i].source.loop = soundList.soundDatas[i].loop;
            soundList.soundDatas[i].source.playOnAwake = soundList.soundDatas[i].playOnAwake;
        }
    }
}
