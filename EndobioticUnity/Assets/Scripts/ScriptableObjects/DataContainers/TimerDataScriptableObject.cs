/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 14, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the scriptable object data container class for timer data.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "Scriptable Objects/Data Containers/Timer Data")]
public class TimerDataScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private float m_timeInSeconds;
    [SerializeField] private TimerMode m_timerMode;
    [SerializeField] private float m_startTimeInSeconds;
    [SerializeField] private bool m_startTimer = false;
    [SerializeField] private bool m_UpdateUI = false;
    #endregion

    #region Getters and Setters
    public float timeInSeconds { get { return m_timeInSeconds; } set { m_timeInSeconds = value; } }
    public TimerMode timerMode { get { return m_timerMode; } }
    public float startTimeInSeconds { get { return m_startTimeInSeconds; } set { m_startTimeInSeconds = value; } }
    public bool startTimer { get { return m_startTimer; } set { m_startTimer = value; } }
    public bool updateUI { get { return m_UpdateUI; } set { m_UpdateUI = value; } }
    #endregion

    #region Reset Data Methods
    public void Reset()
    {
        m_timeInSeconds = m_startTimeInSeconds;
        m_startTimer = false;
        m_UpdateUI = false;
    }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        Reset();
    }
    #endregion
}
