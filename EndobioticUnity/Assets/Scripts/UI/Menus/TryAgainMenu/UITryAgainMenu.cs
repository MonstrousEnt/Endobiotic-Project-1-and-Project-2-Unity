/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: April 2, 2023
 * Description: This is the UI class for try again menu.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITryAgainMenu : UIMenuBase
{
    #region Class Variables
    [Header("Point System")]
    [SerializeField] private UIPiontSystem m_piontSystem;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_restartLevelUnityEvent;
    [SerializeField] private UnityEvent m_loadNextScenceUnityEvent;
    #endregion

    #region UI Base - Override Methods - Try Again Menu
    public override void EnableMenu()
    {
        base.EnableMenu();

        m_piontSystem.DisplayPoints();
    }
    #endregion

    #region UI Methods
    public void TryAgin()
    {
        DisableMenu();

        m_restartLevelUnityEvent?.Invoke();
        m_loadNextScenceUnityEvent?.Invoke();
    }
    #endregion
}
