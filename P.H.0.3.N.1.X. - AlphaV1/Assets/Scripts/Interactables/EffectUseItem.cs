using UnityEngine;

/// <summary>
/// This effect class is for using a item.
/// </summary>

public class EffectUseItem : MonoBehaviour
{
    #region Class Variables
    [Header("Tag Scriptabe Object")]
    [SerializeField] private TagDataScriptableObject m_tagDataPlayer;
    #endregion

    #region Item Methods
    public void UseItem()
    {
        GameObject.FindGameObjectWithTag(m_tagDataPlayer.tagName).GetComponent<CharacterItemHolder>().UseItem();
    }
    #endregion
}
