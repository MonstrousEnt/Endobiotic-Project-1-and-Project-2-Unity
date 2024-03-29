/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 2, 2023
 * Last Updated: April 2, 2023
 * Description: This is the scriptable object list class for level list.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Scriptable Objects/Lists/Level List")]
public class LevelListScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private List<LevelDataScriptableObject> m_levelDatas = new List<LevelDataScriptableObject>();
    #endregion

    #region Getters and Setters
    public List<LevelDataScriptableObject> levelDatas { get { return m_levelDatas; } set { m_levelDatas = value; } }

    public int GetLevelById(string a_id)
    {
        for (int i = 0; i < m_levelDatas.Count; i++)
        {
            if (m_levelDatas[i].id == a_id)
            {
                return i;
            }
        }

        return 0;
    }
    #endregion
}