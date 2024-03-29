/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 2, 2023
 * Last Updated: April 2, 2023
 * Description: This is the UI Base class for menus.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class UIMenuBase : UIBase
{
    #region Class Variables
    [Header("UI Components")]
    [SerializeField] protected GameObject m_firstButtonGameObject;

    [Header("Global Variable Scriptable Object - Player Manager")]
    [SerializeField] protected BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove;

    [Header("Game Events Scriptable Object - Settings Manager")]
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerEnablePause;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerDisablePause;

    [Header("Game Events Scriptable Object - UI Manager - Fade Background")]
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerEnableFadeBackground;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerDisableFadeBackground;

    [Header("Pop Up Data Scriptable Object")]
    [SerializeField] protected PopUpDataScriptableObject m_popUpDataQuitPopUp;

    [Header("Game Events Scriptable Object - UI Manger - Pop Up")]
    [SerializeField] protected PopUpDataGameEventScriptableObject m_popUpDataGameEventUIMangerSetPopUpData;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerEnablePopUp;
    #endregion

    #region Getters and Setters
    protected void SetFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);
    }
    #endregion

    #region UI Menu Base - UI Menu Methods 
    public virtual void EnableMenu()
    {
        m_voidGameEventSettingsManagerEnablePause.Raise();
        m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove.DisableBooleanFlag();
        m_voidGameEventUIManagerEnableFadeBackground.Raise();
        SetFirstButton();
        EnableMainWindow();
    }

    public virtual void DisableMenu()
    {
        m_voidGameEventSettingsManagerDisablePause.Raise();
        m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove.EnableBoolFlag();
        m_voidGameEventUIManagerDisableFadeBackground.Raise();
        DisableMainWindow();
    }

    public void OpenQuitPopUp()
    {
        m_popUpDataGameEventUIMangerSetPopUpData.Raise(m_popUpDataQuitPopUp);
        m_voidGameEventUIManagerEnablePopUp.Raise();
    }
    #endregion
}
