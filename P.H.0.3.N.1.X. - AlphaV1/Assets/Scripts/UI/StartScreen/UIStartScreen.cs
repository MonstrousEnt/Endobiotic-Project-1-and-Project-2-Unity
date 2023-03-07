using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStartScreen : MonoBehaviour
{
    #region Class Variables 
    [Header("Audio Data")]
    [SerializeField] private AudioDataScriptableObject m_audioDataStartScreenSoundtrack;

    [Header("Audio Data Game Event - Audio Manager")]
    [SerializeField] private AudioDataGameEventScriptableObject m_audioDataGameEventEnableLoop;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioDataGameEventPlaySound;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_unityEventStartGame;
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_audioDataGameEventEnableLoop.Raise(m_audioDataStartScreenSoundtrack);
        m_audioDataGameEventPlaySound.Raise(m_audioDataStartScreenSoundtrack);
    }

    void Update()
    {
        //stop the start screen soundtrack and load next level when the user press any key
        if (Input.anyKeyDown)
        {
            m_unityEventStartGame.Invoke();
        }
    }
    #endregion
}