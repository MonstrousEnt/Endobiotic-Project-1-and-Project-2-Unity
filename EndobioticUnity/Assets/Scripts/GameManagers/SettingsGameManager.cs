/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: April 2, 2023
 * Description: This is the game manager class for game settings.
 * Notes: 
 * Resources: 
 *	PAUSE MENU in Unity: https://youtu.be/JivuXdrIHK0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGameManager : MonoBehaviour
{
    #region Class Variables
    [Header("Pause Data")]
	[SerializeField] private bool m_gameIsPause = false;

	[Header("FPS Data")]
	[SerializeField] private int m_lockFps = 60;
	[SerializeField] private int m_fps;
    #endregion

    #region Getters and Setters
    private void setFPS(int a_fps)
	{
		m_fps = Application.targetFrameRate = a_fps;
	}
	private void disableVsync()
	{
		QualitySettings.vSyncCount = 0;
	}
	#endregion

	#region Settings Game Events
	public void EnablePause()
	{
		m_gameIsPause = true;
		Time.timeScale = 0f;
	}
	public void DisablePause()
	{
		m_gameIsPause = false;
		Time.timeScale = 1f;
	}
	#endregion

	#region Unity Methods
	private void Start()
	{
		DisablePause();
		disableVsync();
		setFPS(m_lockFps);
	}
    #endregion

}
