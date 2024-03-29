/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 14, 2023
 * Last Updated: April 2, 2023
 * Description: This is the UI class for pop up.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIPopUp : UIBase
{
    #region Class Variables
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI m_messageTextBox;
    [SerializeField] private GameObject m_yesButtonGameObject;
    [SerializeField] private GameObject m_noButtonGameObject;

    [Header("Controller Inputs")]
    [SerializeField] private GameObject m_popUpFirstButton;

    [Header("Pop Up Data")]
    [SerializeField] private PopUpDataScriptableObject m_popUpData;
    #endregion

    #region Getters and Setters
    public void SetPopUpData(PopUpDataScriptableObject a_popUpData)
    {
        this.m_popUpData = null;

        this.m_popUpData = a_popUpData;
    }
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (Input.anyKey)
        {
            if (m_popUpData != null)
            {
                if (m_popUpData.isReadyToClose)
                {
                    DisablePopUp();
                }
            }
        }
    }
    #endregion

    #region UI Pop Up Methods
    public void EnablePopUp()
    {
        displayPopUpData();
        EnableMainWindow();
    }

    public void DisablePopUp()
    {
        DisableMainWindow();
    }
    private void displayPopUpData()
    {
        if (m_popUpData != null)
        {
            cleanUIData();

            m_messageTextBox.text = m_popUpData.message;

            if (m_popUpData.isConfirm)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(m_popUpFirstButton);

                m_yesButtonGameObject.SetActive(true);
                m_noButtonGameObject.SetActive(true);
            }
        }
    }

    private void cleanUIData()
    {
        m_messageTextBox.text = "";
        m_yesButtonGameObject.SetActive(false);
        m_noButtonGameObject.SetActive(false);
    }
    #endregion
    
    #region On Click Methods 
    public void YesActionPopUpOnClick()
    {
        if (m_popUpData != null)
        {
            m_popUpData.popUpActionUnityEvent?.Invoke();
        }
    }
    #endregion
}