using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Data Containers/Audio Data")]
public class AudioDataScriptableObject : ScriptableObject
{
    [SerializeField] private AudioClip m_clip;
    [SerializeField] private string m_audioGameObjectName;
    [SerializeField] private float m_volume;
    [SerializeField] private float m_pitch;
    [SerializeField] private bool m_loop;
    [SerializeField] private bool m_playOnAwake = false;

    private AudioSource m_source;

    #region Getters and Setters
    public AudioClip clip { get { return m_clip; } set { m_clip = value; } }
    public string audioGameObjectName { get { return m_audioGameObjectName; } set { m_audioGameObjectName = value; } }
    public float volume { get { return m_volume; } set { m_volume = value; } }
    public float pitch { get { return m_pitch; } set { m_pitch = value; } }
    public bool loop { get { return m_loop; } set { m_loop = value; } }
    public bool playOnAwake { get { return m_playOnAwake; } set { m_playOnAwake = value; } }
    public AudioSource source { get { return m_source; } set { m_source = value; } }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
		source = null;
    }
    #endregion
}