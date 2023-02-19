using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITryAgainMenu : MonoBehaviour
{

    [SerializeField] private PopUpData popUpDataQuitPopUp;

    [SerializeField]  private GameObject mainWindowGameObject;

    [SerializeField] private UIPiontSystem piontSystem;


    [SerializeField] private GameObject tryAgainFirstButton;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.activeTryAgainMneuUnityEvent.AddListener(activeTryAgainMneu);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activeTryAgainMneuUnityEvent.RemoveListener(activeTryAgainMneu);
    }

    private void activeTryAgainMneu(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        GameMangerRootMaster.instance.uIEvents.tryAgainIsActive = activeFlag;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);

        //set a new selected object
        EventSystem.current.SetSelectedGameObject(tryAgainFirstButton);

        piontSystem.DisplayPoints();
        mainWindowGameObject.SetActive(activeFlag);
    }

    public void TryAgin()
    {
        activeTryAgainMneu(false);

        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.levelManager.Level1Restart();

        //GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(LevelName.StartScreen);
        SceneManager.LoadScene(LevelName.StartScreen.ToString());
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(true);
    }
}
